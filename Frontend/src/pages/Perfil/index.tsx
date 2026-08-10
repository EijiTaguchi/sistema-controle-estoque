import { PageContainer } from "../../components/layouts/PageContainer";
import { PageHeader } from "../../components/layouts/PageHeader";
import { Button } from "../../components/ui/button";

export default function Perfil() {
     return(
        <PageContainer>
            <PageHeader title="Perfil" description="Verifique as informações do seu perfil">
                <Button>Editar Perfil</Button>
            </PageHeader>
        </PageContainer>
    )
}
