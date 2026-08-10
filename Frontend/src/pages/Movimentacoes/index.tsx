import { PageContainer } from "../../components/layouts/PageContainer";
import { PageHeader } from "../../components/layouts/PageHeader";
import { Button } from "../../components/ui/button";

export default function Movimentacoes() {
     return(
        <PageContainer>
            <PageHeader title="Movimentações" description="Verifique as movimentações de um produto">
            <Button>Adicionar Movimentação</Button>
            </PageHeader>
        </PageContainer>
    )
}