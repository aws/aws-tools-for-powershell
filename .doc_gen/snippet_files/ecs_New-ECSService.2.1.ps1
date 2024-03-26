$lb = @{
    LoadBalancerName = "EC2Contai-EcsElast-S06278JGSJCM"
    ContainerName = "simple-demo"
    ContainerPort = 80
}        
New-ECSService -ServiceName ecs-simple-service -TaskDefinition ecs-demo -DesiredCount 10 -LoadBalancer $lb