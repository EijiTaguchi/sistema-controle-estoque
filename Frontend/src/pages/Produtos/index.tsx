import { PageContainer } from "../../components/layouts/PageContainer";
import { PageHeader } from "../../components/layouts/PageHeader";
import { Button } from "../../components/ui/button";

export default function Produtos() {
    return(
            <PageContainer>
                <PageHeader title="Produtos" description="Verifique os produtos do sistema">
                    <Button>Adicionar Produto</Button>
                </PageHeader>
            </PageContainer>
        )
}
