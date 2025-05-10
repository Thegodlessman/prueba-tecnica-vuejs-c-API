<template>
    <div class="modal fade" :class="{ 'show d-block': visible }" tabindex="-1" role="dialog"
        aria-labelledby="userDetailsModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="userDetailsModalLabel">Detalles del Usuario</h5>
                    <button type="button" class="btn-close" aria-label="Close" @click="closeModal"></button>
                </div>
                <div class="modal-body">
                    <div v-if="user">
                        <p><strong>ID:</strong> {{ user.id }}</p>
                        <p><strong>Nombre:</strong> {{ user.name }}</p>
                        <p><strong>Nombre de Usuario:</strong> {{ user.username }}</p>
                        <p><strong>Email:</strong> {{ user.email }}</p>
                        <p><strong>Teléfono:</strong> {{ user.phone }}</p>
                        <p><strong>Sitio Web:</strong> {{ user.website }}</p>
                        <p>
                            <strong>Dirección:</strong> {{ user.address.street }}, {{ user.address.suite }},
                            {{ user.address.city }} - {{ user.address.zipcode }}
                        </p>
                        <p>
                            <strong>Empresa:</strong> {{ user.company.name }} ({{ user.company.catchPhrase }})
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'UserDetailsModal',
    props: {
        visible: {
            type: Boolean,
            required: true
        },
        user: {
            type: Object,
            default: null
        }
    },
    methods: {
        closeModal() {
            this.$emit('close');
        }
    }
};
</script>

<style scoped>

</style>