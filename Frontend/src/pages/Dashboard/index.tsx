import { PageContainer } from "../../components/layouts/PageContainer";
import { PageHeader } from "../../components/layouts/PageHeader";
import { Button } from "../../components/ui/button";

export default function Dashboard() {
    return (
        <PageContainer>
            <PageHeader title="Dashboard" description="Visualize um resumo do sistema de controle de estoque.">
                <Button variant="outline">Exportar</Button>
            </PageHeader>
        </PageContainer>
    )
}