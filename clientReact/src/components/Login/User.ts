export type UserType = {
    [x: string]: any,
    id: string,
    firstName: string,
    lastName: string,
    email: string,
    password: string
}

export type Action = {
    type: 'CREATE' | 'UPDATE' | 'GET' | 'REMOVE',
    data: Partial<UserType>
}

export const UserReducer =
    (state: UserType, action: Action): UserType => {
        switch (action.type) {
            case 'CREATE':
                return { ...state, ...action.data };
            case 'UPDATE':
                return { ...state, ...action.data };
            case 'REMOVE':
                return {
                    id: '',
                    firstName: '',
                    lastName: '',
                    email: '',
                    password: ''
                };
            default:
                return state;
        }
    }