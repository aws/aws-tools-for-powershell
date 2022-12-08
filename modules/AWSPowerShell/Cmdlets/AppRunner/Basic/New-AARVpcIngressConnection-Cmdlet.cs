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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Create an App Runner VPC Ingress Connection resource. App Runner requires this resource
    /// when you want to associate your App Runner service with an Amazon VPC endpoint.
    /// </summary>
    [Cmdlet("New", "AARVpcIngressConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRunner.Model.VpcIngressConnection")]
    [AWSCmdlet("Calls the AWS App Runner CreateVpcIngressConnection API operation.", Operation = new[] {"CreateVpcIngressConnection"}, SelectReturnType = typeof(Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.VpcIngressConnection or Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.VpcIngressConnection object.",
        "The service call response (type Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAARVpcIngressConnectionCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        #region Parameter ServiceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for this App Runner service that is used to create
        /// the VPC Ingress Connection resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of metadata items that you can associate with the VPC Ingress Connection
        /// resource. A tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppRunner.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter IngressVpcConfiguration_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC endpoint that your App Runner service connects to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressVpcConfiguration_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter IngressVpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that is used for the VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressVpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter VpcIngressConnectionName
        /// <summary>
        /// <para>
        /// <para>A name for the VPC Ingress Connection resource. It must be unique across all the active
        /// VPC Ingress Connections in your Amazon Web Services account in the Amazon Web Services
        /// Region. </para>
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
        public System.String VpcIngressConnectionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcIngressConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcIngressConnection";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcIngressConnectionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcIngressConnectionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcIngressConnectionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcIngressConnectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AARVpcIngressConnection (CreateVpcIngressConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse, NewAARVpcIngressConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcIngressConnectionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IngressVpcConfiguration_VpcEndpointId = this.IngressVpcConfiguration_VpcEndpointId;
            context.IngressVpcConfiguration_VpcId = this.IngressVpcConfiguration_VpcId;
            context.ServiceArn = this.ServiceArn;
            #if MODULAR
            if (this.ServiceArn == null && ParameterWasBound(nameof(this.ServiceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppRunner.Model.Tag>(this.Tag);
            }
            context.VpcIngressConnectionName = this.VpcIngressConnectionName;
            #if MODULAR
            if (this.VpcIngressConnectionName == null && ParameterWasBound(nameof(this.VpcIngressConnectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcIngressConnectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRunner.Model.CreateVpcIngressConnectionRequest();
            
            
             // populate IngressVpcConfiguration
            var requestIngressVpcConfigurationIsNull = true;
            request.IngressVpcConfiguration = new Amazon.AppRunner.Model.IngressVpcConfiguration();
            System.String requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId = null;
            if (cmdletContext.IngressVpcConfiguration_VpcEndpointId != null)
            {
                requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId = cmdletContext.IngressVpcConfiguration_VpcEndpointId;
            }
            if (requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId != null)
            {
                request.IngressVpcConfiguration.VpcEndpointId = requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId;
                requestIngressVpcConfigurationIsNull = false;
            }
            System.String requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId = null;
            if (cmdletContext.IngressVpcConfiguration_VpcId != null)
            {
                requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId = cmdletContext.IngressVpcConfiguration_VpcId;
            }
            if (requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId != null)
            {
                request.IngressVpcConfiguration.VpcId = requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId;
                requestIngressVpcConfigurationIsNull = false;
            }
             // determine if request.IngressVpcConfiguration should be set to null
            if (requestIngressVpcConfigurationIsNull)
            {
                request.IngressVpcConfiguration = null;
            }
            if (cmdletContext.ServiceArn != null)
            {
                request.ServiceArn = cmdletContext.ServiceArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcIngressConnectionName != null)
            {
                request.VpcIngressConnectionName = cmdletContext.VpcIngressConnectionName;
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
        
        private Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.CreateVpcIngressConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "CreateVpcIngressConnection");
            try
            {
                #if DESKTOP
                return client.CreateVpcIngressConnection(request);
                #elif CORECLR
                return client.CreateVpcIngressConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String IngressVpcConfiguration_VpcEndpointId { get; set; }
            public System.String IngressVpcConfiguration_VpcId { get; set; }
            public System.String ServiceArn { get; set; }
            public List<Amazon.AppRunner.Model.Tag> Tag { get; set; }
            public System.String VpcIngressConnectionName { get; set; }
            public System.Func<Amazon.AppRunner.Model.CreateVpcIngressConnectionResponse, NewAARVpcIngressConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcIngressConnection;
        }
        
    }
}
