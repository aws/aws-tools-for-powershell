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
using Amazon.ResourceGroupsTaggingAPI;
using Amazon.ResourceGroupsTaggingAPI.Model;

namespace Amazon.PowerShell.Cmdlets.RGT
{
    /// <summary>
    /// Removes the specified tags from the specified resources. When you specify a tag key,
    /// the action removes both that key and its associated value. The operation succeeds
    /// even if you attempt to remove tags from a resource that were already removed. Note
    /// the following:
    /// 
    ///  <ul><li><para>
    /// To remove tags from a resource, you need the necessary permissions for the service
    /// that the resource belongs to as well as permissions for removing tags. For more information,
    /// see the documentation for the service whose resource you want to untag.
    /// </para></li><li><para>
    /// You can only tag resources that are located in the specified AWS Region for the calling
    /// AWS account.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "RGTResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API UntagResources API operation.", Operation = new[] {"UntagResources"}, SelectReturnType = typeof(Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse))]
    [AWSCmdletOutput("System.String or Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveRGTResourceTagCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceARNList
        /// <summary>
        /// <para>
        /// <para>Specifies a list of ARNs of the resources that you want to remove tags from.</para><para>An ARN (Amazon Resource Name) uniquely identifies a resource. For more information,
        /// see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a> in the <i>AWS General Reference</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] ResourceARNList { get; set; }
        #endregion
        
        #region Parameter TagKey
        /// <summary>
        /// <para>
        /// <para>Specifies a list of tag keys that you want to remove from the specified resources.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TagKeys")]
        public System.String[] TagKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedResourcesMap'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse).
        /// Specifying the name of a property of type Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedResourcesMap";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceARNList parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceARNList' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceARNList' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceARNList), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RGTResourceTag (UntagResources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse, RemoveRGTResourceTagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceARNList;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ResourceARNList != null)
            {
                context.ResourceARNList = new List<System.String>(this.ResourceARNList);
            }
            #if MODULAR
            if (this.ResourceARNList == null && ParameterWasBound(nameof(this.ResourceARNList)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceARNList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagKey != null)
            {
                context.TagKey = new List<System.String>(this.TagKey);
            }
            #if MODULAR
            if (this.TagKey == null && ParameterWasBound(nameof(this.TagKey)))
            {
                WriteWarning("You are passing $null as a value for parameter TagKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesRequest();
            
            if (cmdletContext.ResourceARNList != null)
            {
                request.ResourceARNList = cmdletContext.ResourceARNList;
            }
            if (cmdletContext.TagKey != null)
            {
                request.TagKeys = cmdletContext.TagKey;
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
        
        private Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse CallAWSServiceOperation(IAmazonResourceGroupsTaggingAPI client, Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups Tagging API", "UntagResources");
            try
            {
                #if DESKTOP
                return client.UntagResources(request);
                #elif CORECLR
                return client.UntagResourcesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ResourceARNList { get; set; }
            public List<System.String> TagKey { get; set; }
            public System.Func<Amazon.ResourceGroupsTaggingAPI.Model.UntagResourcesResponse, RemoveRGTResourceTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedResourcesMap;
        }
        
    }
}
