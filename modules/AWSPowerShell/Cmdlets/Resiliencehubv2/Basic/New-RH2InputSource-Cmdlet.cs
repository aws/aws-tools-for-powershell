/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Resiliencehubv2;
using Amazon.Resiliencehubv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RH2
{
    /// <summary>
    /// Creates an input source for a service.
    /// </summary>
    [Cmdlet("New", "RH2InputSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Resiliencehubv2.Model.CreateInputSourceResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub V2 CreateInputSource API operation.", Operation = new[] {"CreateInputSource"}, SelectReturnType = typeof(Amazon.Resiliencehubv2.Model.CreateInputSourceResponse))]
    [AWSCmdletOutput("Amazon.Resiliencehubv2.Model.CreateInputSourceResponse",
        "This cmdlet returns an Amazon.Resiliencehubv2.Model.CreateInputSourceResponse object containing multiple properties."
    )]
    public partial class NewRH2InputSourceCmdlet : AmazonResiliencehubv2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceConfiguration_CfnStackArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfiguration_CfnStackArn { get; set; }
        #endregion
        
        #region Parameter ResourceConfiguration_Eks_ClusterArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfiguration_Eks_ClusterArn { get; set; }
        #endregion
        
        #region Parameter ResourceConfiguration_DesignFileS3Url
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfiguration_DesignFileS3Url { get; set; }
        #endregion
        
        #region Parameter ResourceConfiguration_Eks_Namespace
        /// <summary>
        /// <para>
        /// <para>The list of Kubernetes namespaces within the EKS cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfiguration_Eks_Namespaces")]
        public System.String[] ResourceConfiguration_Eks_Namespace { get; set; }
        #endregion
        
        #region Parameter ResourceConfiguration_ResourceTag
        /// <summary>
        /// <para>
        /// <para>The resource tags for tag-based resource discovery.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfiguration_ResourceTags")]
        public Amazon.Resiliencehubv2.Model.ResourceTag[] ResourceConfiguration_ResourceTag { get; set; }
        #endregion
        
        #region Parameter ServiceArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ServiceArn { get; set; }
        #endregion
        
        #region Parameter ResourceConfiguration_TfStateFileUrl
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfiguration_TfStateFileUrl { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Resiliencehubv2.Model.CreateInputSourceResponse).
        /// Specifying the name of a property of type Amazon.Resiliencehubv2.Model.CreateInputSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RH2InputSource (CreateInputSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Resiliencehubv2.Model.CreateInputSourceResponse, NewRH2InputSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ResourceConfiguration_CfnStackArn = this.ResourceConfiguration_CfnStackArn;
            context.ResourceConfiguration_DesignFileS3Url = this.ResourceConfiguration_DesignFileS3Url;
            context.ResourceConfiguration_Eks_ClusterArn = this.ResourceConfiguration_Eks_ClusterArn;
            if (this.ResourceConfiguration_Eks_Namespace != null)
            {
                context.ResourceConfiguration_Eks_Namespace = new List<System.String>(this.ResourceConfiguration_Eks_Namespace);
            }
            if (this.ResourceConfiguration_ResourceTag != null)
            {
                context.ResourceConfiguration_ResourceTag = new List<Amazon.Resiliencehubv2.Model.ResourceTag>(this.ResourceConfiguration_ResourceTag);
            }
            context.ResourceConfiguration_TfStateFileUrl = this.ResourceConfiguration_TfStateFileUrl;
            context.ServiceArn = this.ServiceArn;
            #if MODULAR
            if (this.ServiceArn == null && ParameterWasBound(nameof(this.ServiceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Resiliencehubv2.Model.CreateInputSourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ResourceConfiguration
            var requestResourceConfigurationIsNull = true;
            request.ResourceConfiguration = new Amazon.Resiliencehubv2.Model.ResourceConfiguration();
            System.String requestResourceConfiguration_resourceConfiguration_CfnStackArn = null;
            if (cmdletContext.ResourceConfiguration_CfnStackArn != null)
            {
                requestResourceConfiguration_resourceConfiguration_CfnStackArn = cmdletContext.ResourceConfiguration_CfnStackArn;
            }
            if (requestResourceConfiguration_resourceConfiguration_CfnStackArn != null)
            {
                request.ResourceConfiguration.CfnStackArn = requestResourceConfiguration_resourceConfiguration_CfnStackArn;
                requestResourceConfigurationIsNull = false;
            }
            System.String requestResourceConfiguration_resourceConfiguration_DesignFileS3Url = null;
            if (cmdletContext.ResourceConfiguration_DesignFileS3Url != null)
            {
                requestResourceConfiguration_resourceConfiguration_DesignFileS3Url = cmdletContext.ResourceConfiguration_DesignFileS3Url;
            }
            if (requestResourceConfiguration_resourceConfiguration_DesignFileS3Url != null)
            {
                request.ResourceConfiguration.DesignFileS3Url = requestResourceConfiguration_resourceConfiguration_DesignFileS3Url;
                requestResourceConfigurationIsNull = false;
            }
            List<Amazon.Resiliencehubv2.Model.ResourceTag> requestResourceConfiguration_resourceConfiguration_ResourceTag = null;
            if (cmdletContext.ResourceConfiguration_ResourceTag != null)
            {
                requestResourceConfiguration_resourceConfiguration_ResourceTag = cmdletContext.ResourceConfiguration_ResourceTag;
            }
            if (requestResourceConfiguration_resourceConfiguration_ResourceTag != null)
            {
                request.ResourceConfiguration.ResourceTags = requestResourceConfiguration_resourceConfiguration_ResourceTag;
                requestResourceConfigurationIsNull = false;
            }
            System.String requestResourceConfiguration_resourceConfiguration_TfStateFileUrl = null;
            if (cmdletContext.ResourceConfiguration_TfStateFileUrl != null)
            {
                requestResourceConfiguration_resourceConfiguration_TfStateFileUrl = cmdletContext.ResourceConfiguration_TfStateFileUrl;
            }
            if (requestResourceConfiguration_resourceConfiguration_TfStateFileUrl != null)
            {
                request.ResourceConfiguration.TfStateFileUrl = requestResourceConfiguration_resourceConfiguration_TfStateFileUrl;
                requestResourceConfigurationIsNull = false;
            }
            Amazon.Resiliencehubv2.Model.EksSource requestResourceConfiguration_resourceConfiguration_Eks = null;
            
             // populate Eks
            var requestResourceConfiguration_resourceConfiguration_EksIsNull = true;
            requestResourceConfiguration_resourceConfiguration_Eks = new Amazon.Resiliencehubv2.Model.EksSource();
            System.String requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_ClusterArn = null;
            if (cmdletContext.ResourceConfiguration_Eks_ClusterArn != null)
            {
                requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_ClusterArn = cmdletContext.ResourceConfiguration_Eks_ClusterArn;
            }
            if (requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_ClusterArn != null)
            {
                requestResourceConfiguration_resourceConfiguration_Eks.ClusterArn = requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_ClusterArn;
                requestResourceConfiguration_resourceConfiguration_EksIsNull = false;
            }
            List<System.String> requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_Namespace = null;
            if (cmdletContext.ResourceConfiguration_Eks_Namespace != null)
            {
                requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_Namespace = cmdletContext.ResourceConfiguration_Eks_Namespace;
            }
            if (requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_Namespace != null)
            {
                requestResourceConfiguration_resourceConfiguration_Eks.Namespaces = requestResourceConfiguration_resourceConfiguration_Eks_resourceConfiguration_Eks_Namespace;
                requestResourceConfiguration_resourceConfiguration_EksIsNull = false;
            }
             // determine if requestResourceConfiguration_resourceConfiguration_Eks should be set to null
            if (requestResourceConfiguration_resourceConfiguration_EksIsNull)
            {
                requestResourceConfiguration_resourceConfiguration_Eks = null;
            }
            if (requestResourceConfiguration_resourceConfiguration_Eks != null)
            {
                request.ResourceConfiguration.Eks = requestResourceConfiguration_resourceConfiguration_Eks;
                requestResourceConfigurationIsNull = false;
            }
             // determine if request.ResourceConfiguration should be set to null
            if (requestResourceConfigurationIsNull)
            {
                request.ResourceConfiguration = null;
            }
            if (cmdletContext.ServiceArn != null)
            {
                request.ServiceArn = cmdletContext.ServiceArn;
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
        
        private Amazon.Resiliencehubv2.Model.CreateInputSourceResponse CallAWSServiceOperation(IAmazonResiliencehubv2 client, Amazon.Resiliencehubv2.Model.CreateInputSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub V2", "CreateInputSource");
            try
            {
                return client.CreateInputSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ResourceConfiguration_CfnStackArn { get; set; }
            public System.String ResourceConfiguration_DesignFileS3Url { get; set; }
            public System.String ResourceConfiguration_Eks_ClusterArn { get; set; }
            public List<System.String> ResourceConfiguration_Eks_Namespace { get; set; }
            public List<Amazon.Resiliencehubv2.Model.ResourceTag> ResourceConfiguration_ResourceTag { get; set; }
            public System.String ResourceConfiguration_TfStateFileUrl { get; set; }
            public System.String ServiceArn { get; set; }
            public System.Func<Amazon.Resiliencehubv2.Model.CreateInputSourceResponse, NewRH2InputSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
