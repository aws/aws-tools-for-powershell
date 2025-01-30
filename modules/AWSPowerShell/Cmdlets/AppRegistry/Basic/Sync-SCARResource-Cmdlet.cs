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
using Amazon.AppRegistry;
using Amazon.AppRegistry.Model;

namespace Amazon.PowerShell.Cmdlets.SCAR
{
    /// <summary>
    /// Syncs the resource with current AppRegistry records.
    /// 
    ///  
    /// <para>
    /// Specifically, the resource’s AppRegistry system tags sync with its associated application.
    /// We remove the resource's AppRegistry system tags if it does not associate with the
    /// application. The caller must have permissions to read and update the resource.
    /// </para>
    /// </summary>
    [Cmdlet("Sync", "SCARResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRegistry.Model.SyncResourceResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog App Registry SyncResource API operation.", Operation = new[] {"SyncResource"}, SelectReturnType = typeof(Amazon.AppRegistry.Model.SyncResourceResponse))]
    [AWSCmdletOutput("Amazon.AppRegistry.Model.SyncResourceResponse",
        "This cmdlet returns an Amazon.AppRegistry.Model.SyncResourceResponse object containing multiple properties."
    )]
    public partial class SyncSCARResourceCmdlet : AmazonAppRegistryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>An entity you can work with and specify with a name or ID. Examples include an Amazon
        /// EC2 instance, an Amazon Web Services CloudFormation stack, or an Amazon S3 bucket.</para>
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
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource of which the application will be associated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppRegistry.ResourceType")]
        public Amazon.AppRegistry.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRegistry.Model.SyncResourceResponse).
        /// Specifying the name of a property of type Amazon.AppRegistry.Model.SyncResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Sync-SCARResource (SyncResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRegistry.Model.SyncResourceResponse, SyncSCARResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Resource = this.Resource;
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRegistry.Model.SyncResourceRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.AppRegistry.Model.SyncResourceResponse CallAWSServiceOperation(IAmazonAppRegistry client, Amazon.AppRegistry.Model.SyncResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog App Registry", "SyncResource");
            try
            {
                #if DESKTOP
                return client.SyncResource(request);
                #elif CORECLR
                return client.SyncResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String Resource { get; set; }
            public Amazon.AppRegistry.ResourceType ResourceType { get; set; }
            public System.Func<Amazon.AppRegistry.Model.SyncResourceResponse, SyncSCARResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
