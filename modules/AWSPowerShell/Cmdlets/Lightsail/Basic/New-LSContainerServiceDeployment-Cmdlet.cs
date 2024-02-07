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
    /// Creates a deployment for your Amazon Lightsail container service.
    /// 
    ///  
    /// <para>
    /// A deployment specifies the containers that will be launched on the container service
    /// and their settings, such as the ports to open, the environment variables to apply,
    /// and the launch command to run. It also specifies the container that will serve as
    /// the public endpoint of the deployment and its settings, such as the HTTP or HTTPS
    /// port to use, and the health check configuration.
    /// </para><para>
    /// You can deploy containers to your container service using container images from a
    /// public registry such as Amazon ECR Public, or from your local machine. For more information,
    /// see <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-creating-container-images">Creating
    /// container images for your Amazon Lightsail container services</a> in the <i>Amazon
    /// Lightsail Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSContainerServiceDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.ContainerService")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateContainerServiceDeployment API operation.", Operation = new[] {"CreateContainerServiceDeployment"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.ContainerService or Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.ContainerService object.",
        "The service call response (type Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSContainerServiceDeploymentCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PublicEndpoint_ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublicEndpoint_ContainerName { get; set; }
        #endregion
        
        #region Parameter PublicEndpoint_ContainerPort
        /// <summary>
        /// <para>
        /// <para>The port of the container to which traffic is forwarded to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PublicEndpoint_ContainerPort { get; set; }
        #endregion
        
        #region Parameter Container
        /// <summary>
        /// <para>
        /// <para>An object that describes the settings of the containers that will be launched on the
        /// container service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Containers")]
        public System.Collections.Hashtable Container { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks successes required before moving the container
        /// to the <c>Healthy</c> state. The default value is <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicEndpoint_HealthCheck_HealthyThreshold")]
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
        [Alias("PublicEndpoint_HealthCheck_IntervalSeconds")]
        public System.Int32? HealthCheck_IntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Path
        /// <summary>
        /// <para>
        /// <para>The path on the container on which to perform the health check. The default value
        /// is <c>/</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicEndpoint_HealthCheck_Path")]
        public System.String HealthCheck_Path { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the container service for which to create the deployment.</para>
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
        [Alias("PublicEndpoint_HealthCheck_SuccessCodes")]
        public System.String HealthCheck_SuccessCode { get; set; }
        #endregion
        
        #region Parameter HealthCheck_TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, during which no response means a failed health check.
        /// You can specify between 2 and 60 seconds. The default value is <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicEndpoint_HealthCheck_TimeoutSeconds")]
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
        [Alias("PublicEndpoint_HealthCheck_UnhealthyThreshold")]
        public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerService'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerService";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSContainerServiceDeployment (CreateContainerServiceDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse, NewLSContainerServiceDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Container != null)
            {
                context.Container = new Dictionary<System.String, Amazon.Lightsail.Model.Container>(StringComparer.Ordinal);
                foreach (var hashKey in this.Container.Keys)
                {
                    context.Container.Add((String)hashKey, (Amazon.Lightsail.Model.Container)(this.Container[hashKey]));
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
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Lightsail.Model.CreateContainerServiceDeploymentRequest();
            
            if (cmdletContext.Container != null)
            {
                request.Containers = cmdletContext.Container;
            }
            
             // populate PublicEndpoint
            var requestPublicEndpointIsNull = true;
            request.PublicEndpoint = new Amazon.Lightsail.Model.EndpointRequest();
            System.String requestPublicEndpoint_publicEndpoint_ContainerName = null;
            if (cmdletContext.PublicEndpoint_ContainerName != null)
            {
                requestPublicEndpoint_publicEndpoint_ContainerName = cmdletContext.PublicEndpoint_ContainerName;
            }
            if (requestPublicEndpoint_publicEndpoint_ContainerName != null)
            {
                request.PublicEndpoint.ContainerName = requestPublicEndpoint_publicEndpoint_ContainerName;
                requestPublicEndpointIsNull = false;
            }
            System.Int32? requestPublicEndpoint_publicEndpoint_ContainerPort = null;
            if (cmdletContext.PublicEndpoint_ContainerPort != null)
            {
                requestPublicEndpoint_publicEndpoint_ContainerPort = cmdletContext.PublicEndpoint_ContainerPort.Value;
            }
            if (requestPublicEndpoint_publicEndpoint_ContainerPort != null)
            {
                request.PublicEndpoint.ContainerPort = requestPublicEndpoint_publicEndpoint_ContainerPort.Value;
                requestPublicEndpointIsNull = false;
            }
            Amazon.Lightsail.Model.ContainerServiceHealthCheckConfig requestPublicEndpoint_publicEndpoint_HealthCheck = null;
            
             // populate HealthCheck
            var requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = true;
            requestPublicEndpoint_publicEndpoint_HealthCheck = new Amazon.Lightsail.Model.ContainerServiceHealthCheckConfig();
            System.Int32? requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_HealthyThreshold = null;
            if (cmdletContext.HealthCheck_HealthyThreshold != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_HealthyThreshold = cmdletContext.HealthCheck_HealthyThreshold.Value;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_HealthyThreshold != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck.HealthyThreshold = requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_HealthyThreshold.Value;
                requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = false;
            }
            System.Int32? requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_IntervalSecond = null;
            if (cmdletContext.HealthCheck_IntervalSecond != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_IntervalSecond = cmdletContext.HealthCheck_IntervalSecond.Value;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_IntervalSecond != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck.IntervalSeconds = requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_IntervalSecond.Value;
                requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = false;
            }
            System.String requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_Path = null;
            if (cmdletContext.HealthCheck_Path != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_Path = cmdletContext.HealthCheck_Path;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_Path != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck.Path = requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_Path;
                requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = false;
            }
            System.String requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_SuccessCode = null;
            if (cmdletContext.HealthCheck_SuccessCode != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_SuccessCode = cmdletContext.HealthCheck_SuccessCode;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_SuccessCode != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck.SuccessCodes = requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_SuccessCode;
                requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = false;
            }
            System.Int32? requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_TimeoutSecond = null;
            if (cmdletContext.HealthCheck_TimeoutSecond != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_TimeoutSecond = cmdletContext.HealthCheck_TimeoutSecond.Value;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_TimeoutSecond != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck.TimeoutSeconds = requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_TimeoutSecond.Value;
                requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = false;
            }
            System.Int32? requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold = null;
            if (cmdletContext.HealthCheck_UnhealthyThreshold != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold = cmdletContext.HealthCheck_UnhealthyThreshold.Value;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold != null)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck.UnhealthyThreshold = requestPublicEndpoint_publicEndpoint_HealthCheck_healthCheck_UnhealthyThreshold.Value;
                requestPublicEndpoint_publicEndpoint_HealthCheckIsNull = false;
            }
             // determine if requestPublicEndpoint_publicEndpoint_HealthCheck should be set to null
            if (requestPublicEndpoint_publicEndpoint_HealthCheckIsNull)
            {
                requestPublicEndpoint_publicEndpoint_HealthCheck = null;
            }
            if (requestPublicEndpoint_publicEndpoint_HealthCheck != null)
            {
                request.PublicEndpoint.HealthCheck = requestPublicEndpoint_publicEndpoint_HealthCheck;
                requestPublicEndpointIsNull = false;
            }
             // determine if request.PublicEndpoint should be set to null
            if (requestPublicEndpointIsNull)
            {
                request.PublicEndpoint = null;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
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
        
        private Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateContainerServiceDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateContainerServiceDeployment");
            try
            {
                #if DESKTOP
                return client.CreateContainerServiceDeployment(request);
                #elif CORECLR
                return client.CreateContainerServiceDeploymentAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Lightsail.Model.Container> Container { get; set; }
            public System.String PublicEndpoint_ContainerName { get; set; }
            public System.Int32? PublicEndpoint_ContainerPort { get; set; }
            public System.Int32? HealthCheck_HealthyThreshold { get; set; }
            public System.Int32? HealthCheck_IntervalSecond { get; set; }
            public System.String HealthCheck_Path { get; set; }
            public System.String HealthCheck_SuccessCode { get; set; }
            public System.Int32? HealthCheck_TimeoutSecond { get; set; }
            public System.Int32? HealthCheck_UnhealthyThreshold { get; set; }
            public System.String ServiceName { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateContainerServiceDeploymentResponse, NewLSContainerServiceDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerService;
        }
        
    }
}
