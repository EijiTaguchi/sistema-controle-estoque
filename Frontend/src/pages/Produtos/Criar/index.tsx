import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

import { Button } from "../../../components/ui/button";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "../../../components/ui/card";
import { Input } from "../../../components/ui/input";
import { Label } from "../../../components/ui/label";

import { criarProduto } from "../../../api/produtos";

export default function CriarProduto() {
  const navigate = useNavigate();

  const [nome, setNome] = useState("");
  const [sku, setSku] = useState("");
  const [preco, setPreco] = useState("");
  const [fornecedorId, setFornecedorId] = useState("");

  const [salvando, setSalvando] = useState(false);
  const [error, setError] = useState("");

  async function handleSubmit(event: React.FormEvent) {
    event.preventDefault();

    setError("");

    const precoNumerico = Number(preco);
    const fornecedorNumerico = Number(fornecedorId);

    if (precoNumerico <= 0) {
      setError("O preço deve ser maior que zero.");
      return;
    }

    if (fornecedorNumerico <= 0) {
      setError("Informe um fornecedor válido.");
      return;
    }

    try {
      setSalvando(true);

      const produto = await criarProduto({
        nome,
        sku,
        preco: precoNumerico,
        fornecedorId: fornecedorNumerico,
      });

      navigate(`/produtos/${produto.id}`);
    } catch {
      setError("Não foi possível criar o produto.");
    } finally {
      setSalvando(false);
    }
  }

  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-2xl font-semibold">
          Novo Produto
        </h1>

        <p className="text-sm text-muted-foreground">
          Cadastre um novo produto no estoque.
        </p>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Informações do produto</CardTitle>
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
                placeholder="Ex: Notebook Dell Inspiron"
                required
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="sku">
                SKU
              </Label>

              <Input
                id="sku"
                value={sku}
                onChange={(event) =>
                  setSku(event.target.value)
                }
                placeholder="Ex: NB-DELL-001"
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
                min="0.01"
                value={preco}
                onChange={(event) =>
                  setPreco(event.target.value)
                }
                placeholder="0,00"
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
                placeholder="ID do fornecedor"
                required
              />
            </div>

            <div className="flex justify-end gap-2">
              <Button
                type="button"
                variant="outline"
                asChild
              >
                <Link to="/produtos">
                  Cancelar
                </Link>
              </Button>

              <Button
                type="submit"
                disabled={salvando}
              >
                {salvando
                  ? "Salvando..."
                  : "Criar produto"}
              </Button>
            </div>
          </form>
        </CardContent>
      </Card>
    </div>
  );
}