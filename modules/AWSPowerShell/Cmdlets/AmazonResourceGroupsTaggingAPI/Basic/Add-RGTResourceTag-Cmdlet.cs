/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Not all resources can have tags. For a list of resources that support tagging, see
    /// <a href="http://docs.aws.amazon.com/awsconsolehelpdocs/latest/gsg/supported-resources.html">Supported
    /// Resources</a> in the <i>AWS Resource Groups and Tag Editor User Guide</i>.
    /// </para></li><li><para>
    /// Each resource can have up to 50 tags. For other limits, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html#tag-restrictions">Tag
    /// Restrictions</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.
    /// </para></li><li><para>
    /// You can only tag resources that are located in the specified region for the AWS account.
    /// </para></li><li><para>
    /// To add tags to a resource, you need the necessary permissions for the service that
    /// the resource belongs to as well as permissions for adding tags. For more information,
    /// see <a href="http://docs.aws.amazon.com/awsconsolehelpdocs/latest/gsg/obtaining-permissions-for-tagging.html">Obtaining
    /// Permissions for Tagging</a> in the <i>AWS Resource Groups and Tag Editor User Guide</i>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Add", "RGTResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API TagResources API operation.", Operation = new[] {"TagResources"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] ResourceARNList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you want to add to the specified resources. A tag consists of a key
        /// and a value that you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceARNList", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-RGTResourceTag (TagResources)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.ResourceARNList != null)
            {
                context.ResourceARNList = new List<System.String>(this.ResourceARNList);
            }
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.TagResourcesRequest();
            
            if (cmdletContext.ResourceARNList != null)
            {
                request.ResourceARNList = cmdletContext.ResourceARNList;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FailedResourcesMap;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TagResourcesAsync(request);
                return task.Result;
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
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
