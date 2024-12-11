/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates an Amazon Lightsail container service.
    /// 
    ///  
    /// <para>
    /// A Lightsail container service is a compute resource to which you can deploy containers.
    /// For more information, see <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-container-services">Container
    /// services in Amazon Lightsail</a> in the <i>Lightsail Dev Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSContainerService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.ContainerService")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateContainerService API operation.", Operation = new[] {"CreateContainerService"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateContainerServiceResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.ContainerService or Amazon.Lightsail.Model.CreateContainerServiceResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.ContainerService object.",
        "The service call response (type Amazon.Lightsail.Model.CreateContainerServiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLSContainerServiceCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PublicEndpoint_ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_ContainerName")]
        public System.String PublicEndpoint_ContainerName { get; set; }
        #endregion
        
        #region Parameter PublicEndpoint_ContainerPort
        /// <summary>
        /// <para>
        /// <para>The port of the container to which traffic is forwarded to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_ContainerPort")]
        public System.Int32? PublicEndpoint_ContainerPort { get; set; }
        #endregion
        
        #region Parameter Deployment_Container
        /// <summary>
        /// <para>
        /// <para>An object that describes the configuration for the containers of the deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_Containers")]
        public System.Collections.Hashtable Deployment_Container { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks successes required before moving the container
        /// to the <c>Healthy</c> state. The default value is <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_HealthCheck_HealthyThreshold")]
        public System.Int32? HealthCheck_HealthyThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheck_IntervalSecond
        /// <summary>
        /// <para>
        /// <para>The approximate interval, in seconds, between health checks of an individual container.
        /// You can specify between 5 and 300 seconds. The default value is <c>5</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_HealthCheck_IntervalSeconds")]
        public System.Int32? HealthCheck_IntervalSecond { get; set; }
        #endregion
        
        #region Parameter EcrImagePullerRole_IsActive
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether to activate the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivateRegistryAccess_EcrImagePullerRole_IsActive")]
        public System.Boolean? EcrImagePullerRole_IsActive { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Path
        /// <summary>
        /// <para>
        /// <para>The path on the container on which to perform the health check. The default value
        /// is <c>/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_HealthCheck_Path")]
        public System.String HealthCheck_Path { get; set; }
        #endregion
        
        #region Parameter Power
        /// <summary>
        /// <para>
        /// <para>The power specification for the container service.</para><para>The power specifies the amount of memory, vCPUs, and base monthly cost of each node
        /// of the container service. The <c>power</c> and <c>scale</c> of a container service
        /// makes up its configured capacity. To determine the monthly price of your container
        /// service, multiply the base price of the <c>power</c> with the <c>scale</c> (the number
        /// of nodes) of the service.</para><para>Use the <c>GetContainerServicePowers</c> action to get a list of power options that
        /// you can specify using this parameter, and their base monthly cost.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.ContainerServicePowerName")]
        public Amazon.Lightsail.ContainerServicePowerName Power { get; set; }
        #endregion
        
        #region Parameter PublicDomainName
        /// <summary>
        /// <para>
        /// <para>The public domain names to use with the container service, such as <c>example.com</c>
        /// and <c>www.example.com</c>.</para><para>You can specify up to four public domain names for a container service. The domain
        /// names that you specify are used when you create a deployment with a container configured
        /// as the public endpoint of your container service.</para><para>If you don't specify public domain names, then you can use the default domain of the
        /// container service.</para><important><para>You must create and validate an SSL/TLS certificate before you can use public domain
        /// names with your container service. Use the <c>CreateCertificate</c> action to create
        /// a certificate for the public domain names you want to use with your container service.</para></important><para>You can specify public domain names using a string to array map as shown in the example
        /// later on this page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicDomainNames")]
        public System.Collections.Hashtable PublicDomainName { get; set; }
        #endregion
        
        #region Parameter Scale
        /// <summary>
        /// <para>
        /// <para>The scale specification for the container service.</para><para>The scale specifies the allocated compute nodes of the container service. The <c>power</c>
        /// and <c>scale</c> of a container service makes up its configured capacity. To determine
        /// the monthly price of your container service, multiply the base price of the <c>power</c>
        /// with the <c>scale</c> (the number of nodes) of the service.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Scale { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name for the container service.</para><para>The name that you specify for your container service will make up part of its default
        /// domain. The default domain of a container service is typically <c>https://&lt;ServiceName&gt;.&lt;RandomGUID&gt;.&lt;AWSRegion&gt;.cs.amazonlightsail.com</c>.
        /// If the name of your container service is <c>container-service-1</c>, and it's located
        /// in the US East (Ohio) Amazon Web Services Region (<c>us-east-2</c>), then the domain
        /// for your container service will be like the following example: <c>https://container-service-1.ur4EXAMPLE2uq.us-east-2.cs.amazonlightsail.com</c></para><para>The following are the requirements for container service names:</para><ul><li><para>Must be unique within each Amazon Web Services Region in your Lightsail account.</para></li><li><para>Must contain 1 to 63 characters.</para></li><li><para>Must contain only alphanumeric characters and hyphens.</para></li><li><para>A hyphen (-) can separate words but cannot be at the start or end of the name.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter HealthCheck_SuccessCode
        /// <summary>
        /// <para>
        /// <para>The HTTP codes to use when checking for a successful response from a container. You
        /// can specify values between <c>200</c> and <c>499</c>. You can specify multiple values
        /// (for example, <c>200,202</c>) or a range of values (for example, <c>200-299</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_HealthCheck_SuccessCodes")]
        public System.String HealthCheck_SuccessCode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the container service during create.</para><para>Use the <c>TagResource</c> action to tag a resource after it's created.</para><para>For more information about tags in Lightsail, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-tags">Amazon
        /// Lightsail Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter HealthCheck_TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, during which no response means a failed health check.
        /// You can specify between 2 and 60 seconds. The default value is <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_HealthCheck_TimeoutSeconds")]
        public System.Int32? HealthCheck_TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheck_UnhealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check failures required before moving the container
        /// to the <c>Unhealthy</c> state. The default value is <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Deployment_PublicEndpoint_HealthCheck_UnhealthyThreshold")]
        public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerService'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateContainerServiceResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateContainerServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerService";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSContainerService (CreateContainerService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateContainerServiceResponse, NewLSContainerServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Deployment_Container != null)
            {
                context.Deployment_Container = new Dictionary<System.String, Amazon.Lightsail.Model.Container>(StringComparer.Ordinal);
                foreach (var hashKey in this.Deployment_Container.Keys)
                {
                    context.Deployment_Container.Add((String)hashKey, (Amazon.Lightsail.Model.Container)(this.Deployment_Container[hashKey]));
                }
            }
            context.PublicEndpoint_ContainerName = this.PublicEndpoint_ContainerName;
            context.PublicEndpoint_ContainerPort = this.PublicEndpoint_ContainerPort;
            context.HealthCheck_HealthyThreshold = this.HealthCheck_HealthyThreshold;
            context.HealthCheck_IntervalSecond = this.HealthCheck_IntervalSecond;
            context.HealthCheck_Path = this.HealthCheck_Path;
            context.HealthCheck_SuccessCode = this.HealthCheck_SuccessCode;
            context.HealthCheck_TimeoutSecond = this.HealthCheck_TimeoutSecond;
            context.HealthCheck_UnhealthyThreshold = this.HealthCheck_UnhealthyThreshold;
            context.Power = this.Power;
            #if MODULAR
            if (this.Power == null && ParameterWasBound(nameof(this.Power)))
            {
                WriteWarning("You are passing $null as a value for parameter Power which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EcrImagePullerRole_IsActive = this.EcrImagePullerRole_IsActive;
            if (this.PublicDomainName != null)
            {
                context.PublicDomainName = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.PublicDomainName.Keys)
                {
                    object hashValue = this.PublicDomainName[hashKey];
                    if (hashValue == null)
                    {
                        context.PublicDomainName.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.PublicDomainName.Add((String)hashKey, valueSet);
                }
            }
            context.Scale = this.Scale;
            #if MODULAR
            if (this.Scale == null && ParameterWasBound(nameof(this.Scale)))
            {
                WriteWarning("You are passing $null as a value for parameter Scale which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lightsail.Model.CreateContainerServiceRequest();
            
            
             // populate Deployment
            var requestDeploymentIsNull = true;
            request.Deployment = new Amazon.Lightsail.Model.ContainerServiceDeploymentRequest();
            Dictionary<System.String, Amazon.Lightsail.Model.Container> requestDeployment_deployment_Container = null;
            if (cmdletContext.Deployment_Container != null)
            {
                requestDeployment_deployment_Container = cmdletContext.Deployment_Container;
            }
            if (requestDeployment_deployment_Container != null)
            {
                request.Deployment.Containers = requestDeployment_deployment_Container;
                requestDeploymentIsNull = false;
            }
            Amazon.Lightsail.Model.EndpointRequest requestDeployment_deployment_PublicEndpoint = null;
            
             // populate PublicEndpoint
            var requestDeployment_deployment_PublicEndpointIsNull = true;
            requestDeployment_deployment_PublicEndpoint = new Amazon.Lightsail.Model.EndpointRequest();
            System.String requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerName = null;
            if (cmdletContext.PublicEndpoint_ContainerName != null)
            {
                requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerName = cmdletContext.PublicEndpoint_ContainerName;
            }
            if (requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerName != null)
            {
                requestDeployment_deployment_PublicEndpoint.ContainerName = requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerName;
                requestDeployment_deployment_PublicEndpointIsNull = false;
            }
            System.Int32? requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerPort = null;
            if (cmdletContext.PublicEndpoint_ContainerPort != null)
            {
                requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerPort = cmdletContext.PublicEndpoint_ContainerPort.Value;
            }
            if (requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerPort != null)
            {
                requestDeployment_deployment_PublicEndpoint.ContainerPort = requestDeployment_deployment_PublicEndpoint_publicEndpoint_ContainerPort.Value;
                requestDeployment_deployment_PublicEndpointIsNull = false;
            }
            Amazon.Lightsail.Model.ContainerServiceHealthCheckConfig requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck = null;
            
             // populate HealthCheck
            var requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = true;
            requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck = new Amazon.Lightsail.Model.ContainerServiceHealthCheckConfig();
            System.Int32? requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_HealthyThreshold = null;
            if (cmdletContext.HealthCheck_HealthyThreshold != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_HealthyThreshold = cmdletContext.HealthCheck_HealthyThreshold.Value;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_HealthyThreshold != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck.HealthyThreshold = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_HealthyThreshold.Value;
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = false;
            }
            System.Int32? requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_IntervalSecond = null;
            if (cmdletContext.HealthCheck_IntervalSecond != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_IntervalSecond = cmdletContext.HealthCheck_IntervalSecond.Value;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_IntervalSecond != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck.IntervalSeconds = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_IntervalSecond.Value;
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = false;
            }
            System.String requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_Path = null;
            if (cmdletContext.HealthCheck_Path != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_Path = cmdletContext.HealthCheck_Path;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_Path != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck.Path = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_Path;
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = false;
            }
            System.String requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_SuccessCode = null;
            if (cmdletContext.HealthCheck_SuccessCode != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_SuccessCode = cmdletContext.HealthCheck_SuccessCode;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_SuccessCode != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck.SuccessCodes = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_SuccessCode;
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = false;
            }
            System.Int32? requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_TimeoutSecond = null;
            if (cmdletContext.HealthCheck_TimeoutSecond != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_TimeoutSecond = cmdletContext.HealthCheck_TimeoutSecond.Value;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_TimeoutSecond != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck.TimeoutSeconds = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_TimeoutSecond.Value;
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = false;
            }
            System.Int32? requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold = null;
            if (cmdletContext.HealthCheck_UnhealthyThreshold != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold = cmdletContext.HealthCheck_UnhealthyThreshold.Value;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold != null)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck.UnhealthyThreshold = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold.Value;
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull = false;
            }
             // determine if requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck should be set to null
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheckIsNull)
            {
                requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck = null;
            }
            if (requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck != null)
            {
                requestDeployment_deployment_PublicEndpoint.HealthCheck = requestDeployment_deployment_PublicEndpoint_deployment_PublicEndpoint_HealthCheck;
                requestDeployment_deployment_PublicEndpointIsNull = false;
            }
             // determine if requestDeployment_deployment_PublicEndpoint should be set to null
            if (requestDeployment_deployment_PublicEndpointIsNull)
            {
                requestDeployment_deployment_PublicEndpoint = null;
            }
            if (requestDeployment_deployment_PublicEndpoint != null)
            {
                request.Deployment.PublicEndpoint = requestDeployment_deployment_PublicEndpoint;
                requestDeploymentIsNull = false;
            }
             // determine if request.Deployment should be set to null
            if (requestDeploymentIsNull)
            {
                request.Deployment = null;
            }
            if (cmdletContext.Power != null)
            {
                request.Power = cmdletContext.Power;
            }
            
             // populate PrivateRegistryAccess
            var requestPrivateRegistryAccessIsNull = true;
            request.PrivateRegistryAccess = new Amazon.Lightsail.Model.PrivateRegistryAccessRequest();
            Amazon.Lightsail.Model.ContainerServiceECRImagePullerRoleRequest requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole = null;
            
             // populate EcrImagePullerRole
            var requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRoleIsNull = true;
            requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole = new Amazon.Lightsail.Model.ContainerServiceECRImagePullerRoleRequest();
            System.Boolean? requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive = null;
            if (cmdletContext.EcrImagePullerRole_IsActive != null)
            {
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive = cmdletContext.EcrImagePullerRole_IsActive.Value;
            }
            if (requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive != null)
            {
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole.IsActive = requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole_ecrImagePullerRole_IsActive.Value;
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRoleIsNull = false;
            }
             // determine if requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole should be set to null
            if (requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRoleIsNull)
            {
                requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole = null;
            }
            if (requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole != null)
            {
                request.PrivateRegistryAccess.EcrImagePullerRole = requestPrivateRegistryAccess_privateRegistryAccess_EcrImagePullerRole;
                requestPrivateRegistryAccessIsNull = false;
            }
             // determine if request.PrivateRegistryAccess should be set to null
            if (requestPrivateRegistryAccessIsNull)
            {
                request.PrivateRegistryAccess = null;
            }
            if (cmdletContext.PublicDomainName != null)
            {
                request.PublicDomainNames = cmdletContext.PublicDomainName;
            }
            if (cmdletContext.Scale != null)
            {
                request.Scale = cmdletContext.Scale.Value;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lightsail.Model.CreateContainerServiceResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateContainerServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateContainerService");
            try
            {
                #if DESKTOP
                return client.CreateContainerService(request);
                #elif CORECLR
                return client.CreateContainerServiceAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, Amazon.Lightsail.Model.Container> Deployment_Container { get; set; }
            public System.String PublicEndpoint_ContainerName { get; set; }
            public System.Int32? PublicEndpoint_ContainerPort { get; set; }
            public System.Int32? HealthCheck_HealthyThreshold { get; set; }
            public System.Int32? HealthCheck_IntervalSecond { get; set; }
            public System.String HealthCheck_Path { get; set; }
            public System.String HealthCheck_SuccessCode { get; set; }
            public System.Int32? HealthCheck_TimeoutSecond { get; set; }
            public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
            public Amazon.Lightsail.ContainerServicePowerName Power { get; set; }
            public System.Boolean? EcrImagePullerRole_IsActive { get; set; }
            public Dictionary<System.String, List<System.String>> PublicDomainName { get; set; }
            public System.Int32? Scale { get; set; }
            public System.String ServiceName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateContainerServiceResponse, NewLSContainerServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerService;
        }
        
    }
}
