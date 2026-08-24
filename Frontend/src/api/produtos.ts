import { api } from "./axios";

export type Produto = {
  id: number;
  nome: string;
  sku: string;
  preco: number;
  quantidadeEstoque: number;
  ativo: boolean;
  fornecedorId: number;
  fornecedorNome: string;
};

export type ProdutoPaginado = {
  dados: Produto[];
  pagina: number;
  tamanhoPagina: number;
  totalRegistros: number;
  totalPaginas: number;
};

export type AtualizarProdutoRequest = {
  id: number;
  nome: string;
  preco: number;
  fornecedorId: number;
}

export async function listarProdutos(
  busca = "",
  pagina = 1,
  tamanhoPagina = 10
): Promise<ProdutoPaginado> {
  const response = await api.get("/api/Produto", {
    params: {
      busca,
      pagina,
      tamanhoPagina,
    },
  });

  return response.data;
}

export async function obterProdutoPorId(
  id: number
): Promise<Produto> {
  const response = await api.get(`/api/Produto/${id}`);

  return response.data;
}

export async function criarProduto(
  data: {
    nome: string;
    sku: string;
    preco: number;
    fornecedorId: number;
  }) : Promise<Produto> {
    const response = await api.post("/api/Produto", data);
    return response.data;
  }

  export async function atualizarProduto(
  data: AtualizarProdutoRequest
  ) : Promise<Produto> {
    const response = await api.put(`/api/Produto/${data.id}`, data);
    return response.data;
  }

  export async function desativarProduto(
    id: number
  ) : Promise<Produto> {
    const response = await api.patch(`/api/Produto/${id}/desativar`);
    return response.data;
  }

  