# Running NServicebus locally inside Docker containers

Goal of this POC project is to figure a couple of things out with the intention of getting an distributed event driven application running on a development machine inside docker containers.

- [x] How to run nservicebus locally without installing external tooling
- [x] How to run nservicebus inside a docker container
- [x] How to mount LearningTransport location properly
- [x] If it is possible to use the LearningTransport as a trigger for an Azure function
    - Azure functions only support Azure service bus triggers, you cant run ASB locally or in a docker container, so there is no way to use the LearningTransport as a trigger for an azure function. Proper way to use this in a development environment would be to use the real deal and create namespaces per developer/feature branch.
