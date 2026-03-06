FROM mcr.microsoft.com/devcontainers/typescript-node:20

RUN rm -f /etc/apt/sources.list.d/yarn.list

# Install azcopy
RUN curl -sL https://aka.ms/downloadazcopy-v10-linux | tar xz --strip-components=1 -C /usr/local/bin azcopy_linux_amd64_*/azcopy
