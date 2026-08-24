import { useEffect, useState } from "react";

import { Button } from "../../components/ui/button";
import { Input } from "../../components/ui/input";

import { PageHeader } from "../../components/layouts/PageHeader";
import { listarProdutos, type Produto } from "../../api/produtos";
import { Link } from "react-router-dom";

export default function Produtos() {
  const [produtos, setProdutos] = useState<Produto[]>([]);
  const [busca, setBusca] = useState("");
  const [pagina, setPagina] = useState(1);
  const [totalPaginas, setTotalPaginas] = useState(1);

  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    async function carregarProdutos() {
      try {
        setLoading(true);
        setError("");

        const data = await listarProdutos(
          busca,
          pagina,
          10
        );

        setProdutos(data.dados);
        setTotalPaginas(data.totalPaginas);
      } catch (error) {
        setError("Não foi possível carregar os produtos.");
      } finally {
        setLoading(false);
      }
    }

    carregarProdutos();
  }, [busca, pagina]);

  return (
    <div className="space-y-6">

      <PageHeader
        title="Produtos"
        description="Gerencie os produtos cadastrados."
      >
        <Button>
          <Link to="/produtos/novo">
            Novo Produto
          </Link>
        </Button>
      </PageHeader>

      <Input
        placeholder="Buscar produto..."
        className="max-w-sm"
        value={busca}
        onChange={(event) => {
          setBusca(event.target.value);
          setPagina(1);
        }}
      />

      {loading && (
        <p className="text-sm text-muted-foreground">
          Carregando produtos...
        </p>
      )}

      {error && (
        <p className="text-sm text-destructive">
          {error}
        </p>
      )}

      {!loading && !error && (
        <>
          <div className="rounded-md border">
            <table className="w-full text-sm">

              <thead className="border-b bg-muted/50">
                <tr>
                  <th className="px-4 py-3 text-left">
                    Produto
                  </th>

                  <th className="px-4 py-3 text-left">
                    SKU
                  </th>

                  <th className="px-4 py-3 text-left">
                    Preço
                  </th>

                  <th className="px-4 py-3 text-left">
                    Estoque
                  </th>

                  <th className="px-4 py-3 text-left">
                    Status
                  </th>
                </tr>
              </thead>

              <tbody>
                {produtos.length === 0 ? (
                  <tr>
                    <td
                      colSpan={5}
                      className="px-4 py-8 text-center text-muted-foreground"
                    >
                      Nenhum produto encontrado.
                    </td>
                  </tr>
                ) : (
                  produtos.map((produto) => (
                    <tr
                      key={produto.id}
                      className="border-b last:border-0"
                    >
                      <td className="px-4 py-3 font-medium">
                        <Link
                            to={`/produtos/${produto.id}`}
                            className="hover:underline"
                        >
                            {produto.nome}
                        </Link>
                        </td>

                      <td className="px-4 py-3">
                        {produto.sku}
                      </td>

                      <td className="px-4 py-3">
                        {produto.preco.toLocaleString("pt-BR", {
                          style: "currency",
                          currency: "BRL",
                        })}
                      </td>

                      <td className="px-4 py-3">
                        {produto.quantidadeEstoque}
                      </td>

                      <td className="px-4 py-3">
                        {produto.ativo ? "Ativo" : "Inativo"}
                      </td>
                    </tr>
                  ))
                )}
              </tbody>

            </table>
          </div>

          <div className="flex items-center justify-between pt-4">

            <p className="text-sm text-muted-foreground">
              Página {pagina} de {totalPaginas}
            </p>

            <div className="flex gap-2">

              <Button
                variant="outline"
                disabled={pagina === 1}
                onClick={() =>
                  setPagina((paginaAtual) => paginaAtual - 1)
                }
              >
                Anterior
              </Button>

              <Button
                variant="outline"
                disabled={pagina === totalPaginas}
                onClick={() =>
                  setPagina((paginaAtual) => paginaAtual + 1)
                }
              >
                Próxima
              </Button>

            </div>

          </div>
        </>
      )}

    </div>
  );
}