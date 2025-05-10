<template>
    <div class="container mt-4">
        <h2 class="mb-3">Lista de Usuarios</h2>
        <div class="mb-3"> <input type="text" class="form-control" v-model="searchTerm"
                placeholder="Buscar por nombre o email..." />
        </div>

        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Email</th>
                    <th>Teléfono</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="user in filteredUsers" :key="user.id">
                    <td>{{ user.name }}</td>
                    <td>{{ user.email }}</td>
                    <td>{{ user.phone }}</td>
                    <td>
                        <button class="btn btn-info btn-sm" @click="showDetails(user)">Ver detalles</button>
                    </td>
                </tr>
            </tbody>
        </table>

        <UserDetailsModal :visible="isModalVisible" :user="selectedUser" @close="hideDetails" />

    </div>
</template>

<script>
import axios from 'axios';
import UserDetailsModal from './usersDetails.vue';

export default {
    name: 'UsersTable',
    components: {
        UserDetailsModal
    },
    data() {
        return {
            users: [],
            searchTerm: '',
            isModalVisible: false,
            selectedUser: null
        };
    },
    computed: {
        filteredUsers() {
            if (!this.searchTerm) {
                return this.users;
            }
            const lowerCaseSearchTerm = this.searchTerm.toLowerCase();
            return this.users.filter(user => {
                return (
                    user.name.toLowerCase().includes(lowerCaseSearchTerm) ||
                    user.email.toLowerCase().includes(lowerCaseSearchTerm)
                );
            });
        }
    },
    methods: {
        showDetails(user) {
            this.selectedUser = user;
            this.isModalVisible = true;
        },
        hideDetails() {
            this.isModalVisible = false;
            this.selectedUser = null;
        }
    },
    async created() {
        try {
            const response = await axios.get('https://jsonplaceholder.typicode.com/users');
            this.users = response.data;
        } catch (error) {
            console.error('Error al obtener los usuarios:', error);
        }
    }
};
</script>

<style scoped>
.container {
    margin-top: 20px;
}
</style>