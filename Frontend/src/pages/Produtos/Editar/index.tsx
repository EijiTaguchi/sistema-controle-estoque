import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";

import { Button } from "../../../components/ui/button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "../../../components/ui/card";
import { Input } from "../../../components/ui/input";
import { Label } from "../../../components/ui/label";

import {
  atualizarProduto,
  obterProdutoPorId,
} from "../../../api/produtos";

export default function EditarProduto() {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const [nome, setNome] = useState("");
  const [preco, setPreco] = useState("");
  const [fornecedorId, setFornecedorId] = useState("");

  const [loading, setLoading] = useState(true);
  const [salvando, setSalvando] = useState(false);
  const [error, setError] = useState("");

  useEffect(() => {
    async function carregarProduto() {
      try {
        if (!id) {
          setError("Produto não encontrado.");
          return;
        }

        const produto = await obterProdutoPorId(Number(id));

        setNome(produto.nome);
        setPreco(String(produto.preco));
        setFornecedorId(String(produto.fornecedorId));
      } catch {
        setError("Não foi possível carregar o produto.");
      } finally {
        setLoading(false);
      }
    }

    carregarProduto();
  }, [id]);

  async function handleSubmit(
    event: React.FormEvent
  ) {
    event.preventDefault();

    if (!id) {
      return;
    }

    const produtoId = Number(id);
    const produtoNumerico = Number(preco);
    const fornecedorNumerico = Number(fornecedorId);

    if (Number.isNaN(produtoId)) {
      setError("ID do produto inválido.");
      return;
    }

    if (Number.isNaN(produtoNumerico) || produtoNumerico < 0) {
      setError("Preço inválido.");
      return;
    }

    if (Number.isNaN(fornecedorNumerico) || fornecedorNumerico < 1) {
      setError("Fornecedor inválido.");
      return;
    }

    try {
      setSalvando(true);
      setError("");

      await atualizarProduto({
        id: Number(id),
        nome,
        preco: Number(preco),
        fornecedorId: Number(fornecedorId),
      });

      navigate(`/produtos/${id}`);
    } catch {
      setError("Não foi possível atualizar o produto.");
    } finally {
      setSalvando(false);
    }
  }

  if (loading) {
    return (
      <p className="text-sm text-muted-foreground">
        Carregando produto...
      </p>
    );
  }

  if (error && !nome) {
    return (
      <div className="space-y-4">
        <p className="text-sm text-destructive">
          {error}
        </p>

        <Button variant="outline">
          <Link to="/produtos">
            Voltar
          </Link>
        </Button>
      </div>
    );
  }

  return (
    <div className="space-y-6">

      <div>
        <h1 className="text-2xl font-semibold">
          Editar Produto
        </h1>

        <p className="text-sm text-muted-foreground">
          Atualize as informações do produto.
        </p>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>
            Informações do produto
          </CardTitle>
        </CardHeader>

        <CardContent>
          <form
            onSubmit={handleSubmit}
            className="space-y-6"
          >

            {error && (
              <p className="text-sm text-destructive">
                {error}
              </p>
            )}

            <div className="space-y-2">
              <Label htmlFor="nome">
                Nome
              </Label>

              <Input
                id="nome"
                value={nome}
                onChange={(event) =>
                  setNome(event.target.value)
                }
                required
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="preco">
                Preço
              </Label>

              <Input
                id="preco"
                type="number"
                step="0.01"
                min="0"
                value={preco}
                onChange={(event) =>
                  setPreco(event.target.value)
                }
                required
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="fornecedorId">
                Fornecedor
              </Label>

              <Input
                id="fornecedorId"
                type="number"
                min="1"
                value={fornecedorId}
                onChange={(event) =>
                  setFornecedorId(event.target.value)
                }
                required
              />
            </div>

            <div className="flex justify-end gap-2">

              <Button
                type="button"
                variant="outline"
              >
                <Link to={`/produtos/${id}`}>
                  Cancelar
                </Link>
              </Button>

              <Button
                type="submit"
                disabled={salvando}
              >
                {salvando
                  ? "Salvando..."
                  : "Salvar alterações"}
              </Button>

            </div>

          </form>
        </CardContent>
      </Card>

    </div>
  );
}