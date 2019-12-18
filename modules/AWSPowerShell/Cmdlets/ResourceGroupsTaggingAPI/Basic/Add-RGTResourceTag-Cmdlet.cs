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
    /// Applies one or more tags to the specified resources. Note the following:
    /// 
    ///  <ul><li><para>
    /// Not all resources can have tags. For a list of services that support tagging, see
    /// <a href="http://docs.aws.amazon.com/resourcegroupstagging/latest/APIReference/Welcome.html">this
    /// list</a>.
    /// </para></li><li><para>
    /// Each resource can have up to 50 tags. For other limits, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws_tagging.html#tag-conventions">Tag
    /// Naming and Usage Conventions</a> in the <i>AWS General Reference.</i></para></li><li><para>
    /// You can only tag resources that are located in the specified Region for the AWS account.
    /// </para></li><li><para>
    /// To add tags to a resource, you need the necessary permissions for the service that
    /// the resource belongs to as well as permissions for adding tags. For more information,
    /// see <a href="http://docs.aws.amazon.com/resourcegroupstagging/latest/APIReference/Welcome.html">this
    /// list</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Add", "RGTResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API TagResources API operation.", Operation = new[] {"TagResources"}, SelectReturnType = typeof(Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse))]
    [AWSCmdletOutput("System.String or Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddRGTResourceTagCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceARNList
        /// <summary>
        /// <para>
        /// <para>A list of ARNs. An ARN (Amazon Resource Name) uniquely identifies a resource. You
        /// can specify a minimum of 1 and a maximum of 20 ARNs (resources) to tag. An ARN can
        /// be set to a maximum of 1600 characters. For more information, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you want to add to the specified resources. A tag consists of a key
        /// and a value that you define.</para>
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
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedResourcesMap'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse).
        /// Specifying the name of a property of type Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-RGTResourceTag (TagResources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse, AddRGTResourceTagCmdlet>(Select) ??
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
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            #if MODULAR
            if (this.Tag == null && ParameterWasBound(nameof(this.Tag)))
            {
                WriteWarning("You are passing $null as a value for parameter Tag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesRequest();
            
            if (cmdletContext.ResourceARNList != null)
            {
                request.ResourceARNList = cmdletContext.ResourceARNList;
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
        
        private Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse CallAWSServiceOperation(IAmazonResourceGroupsTaggingAPI client, Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups Tagging API", "TagResources");
            try
            {
                #if DESKTOP
                return client.TagResources(request);
                #elif CORECLR
                return client.TagResourcesAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesResponse, AddRGTResourceTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedResourcesMap;
        }
        
    }
}
