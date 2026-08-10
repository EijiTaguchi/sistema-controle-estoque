import { PageContainer } from "../../components/layouts/PageContainer";
import { PageHeader } from "../../components/layouts/PageHeader";
import { Button } from "../../components/ui/button";

export default function Fornecedores() {
    return(
        <PageContainer>
            <PageHeader title="Fornecedores" description="Verifique os fornecedores de um produto">
            <Button>Adicionar Fornecedor</Button>
            </PageHeader>
        </PageContainer>
    )
}
