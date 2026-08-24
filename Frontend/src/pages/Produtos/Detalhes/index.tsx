import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";

import { Button } from "../../../components/ui/button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "../../../components/ui/card";

import { PageHeader } from "../../../components/layouts/PageHeader";

import {
  desativarProduto,
  obterProdutoPorId,
  type Produto,
} from "../../../api/produtos";

export default function DetalhesProduto() {

  const { id } = useParams<{ id: string }>();

  const [produto, setProduto] = useState<Produto | null>(null);
  const [loading, setLoading] = useState(true);
  const [desativando, setDesativando] = useState(false);
  const [error, setError] = useState("");

  useEffect(() => {
    async function carregarProduto() {
      if (!id) {
        setError("Produto não encontrado.");
        setLoading(false);
        return;
      }

      try {
        setLoading(true);
        setError("");

        const produtoId = Number(id);

        if (Number.isNaN(produtoId)) {
          setError("ID do produto inválido.");
          return;
        }

        const data = await obterProdutoPorId(produtoId);

        setProduto(data);
      } catch {
        setError("Não foi possível carregar o produto.");
      } finally {
        setLoading(false);
      }
    }

    carregarProduto();
  }, [id]);

  async function handleDesativar() {
    if (!id || !produto) {
      return;
    }

    const produtoId = Number(id);

    if (Number.isNaN(produtoId)) {
      setError("ID do produto inválido.");
      return;
    }

    const confirmar = window.confirm(
      `Deseja realmente desativar o produto "${produto.nome}"?`
    );

    if (!confirmar) {
      return;
    }

    try {
      setDesativando(true);
      setError("");

      const produtoDesativado = await desativarProduto(produtoId);

      setProduto(produtoDesativado);
    } catch {
      setError("Não foi possível desativar o produto.");
    } finally {
      setDesativando(false);
    }
  }

  if (loading) {
    return (
      <p className="text-sm text-muted-foreground">
        Carregando produto...
      </p>
    );
  }

  if (error && !produto) {
    return (
      <div className="space-y-4">
        <p className="text-sm text-destructive">
          {error}
        </p>

        <Button variant="outline">
          <Link to="/produtos">
            Voltar para produtos
          </Link>
        </Button>
      </div>
    );
  }

  if (!produto) {
    return (
      <div className="space-y-4">
        <p className="text-sm text-destructive">
          Produto não encontrado.
        </p>

        <Button  variant="outline">
          <Link to="/produtos">
            Voltar para produtos
          </Link>
        </Button>
      </div>
    );
  }

  return (
    <div className="space-y-6">

      <PageHeader
        title={`Produto #${produto.id}`}
        description="Visualize as informações do produto."
      >
        <div className="flex gap-2">

          {produto.ativo && (
            <Button
              variant="outline"
              
            >
              <Link
                to={`/produtos/${produto.id}/editar`}
              >
                Editar
              </Link>
            </Button>
          )}

          {produto.ativo && (
            <Button
              variant="destructive"
              onClick={handleDesativar}
              disabled={desativando}
            >
              {desativando
                ? "Desativando..."
                : "Desativar"}
            </Button>
          )}

          <Button
            variant="outline"
          >
            <Link to="/produtos">
              Voltar
            </Link>
          </Button>

        </div>
      </PageHeader>

      {error && (
        <p className="text-sm text-destructive">
          {error}
        </p>
      )}

      <Card>
        <CardHeader>
          <CardTitle>
            {produto.nome}
          </CardTitle>
        </CardHeader>

        <CardContent>
          <div className="grid gap-6 md:grid-cols-2">

            <div>
              <p className="text-sm text-muted-foreground">
                Nome
              </p>

              <p className="font-medium">
                {produto.nome}
              </p>
            </div>

            <div>
              <p className="text-sm text-muted-foreground">
                SKU
              </p>

              <p className="font-medium">
                {produto.sku}
              </p>
            </div>

            <div>
              <p className="text-sm text-muted-foreground">
                Preço
              </p>

              <p className="font-medium">
                {produto.preco.toLocaleString("pt-BR", {
                  style: "currency",
                  currency: "BRL",
                })}
              </p>
            </div>

            <div>
              <p className="text-sm text-muted-foreground">
                Estoque
              </p>

              <p className="font-medium">
                {produto.quantidadeEstoque}
              </p>
            </div>

            <div>
              <p className="text-sm text-muted-foreground">
                Fornecedor
              </p>

              <p className="font-medium">
                {produto.fornecedorNome}
              </p>
            </div>

            <div>
              <p className="text-sm text-muted-foreground">
                Status
              </p>

              <p className="font-medium">
                {produto.ativo ? "Ativo" : "Inativo"}
              </p>
            </div>

          </div>
        </CardContent>
      </Card>

    </div>
  );
}