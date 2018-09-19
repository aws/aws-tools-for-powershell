/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Adds up to 50 cost allocation tags to the named resource. A cost allocation tag is
    /// a key-value pair where the key and value are case-sensitive. You can use cost allocation
    /// tags to categorize and track your AWS costs.
    /// 
    ///  
    /// <para>
    ///  When you apply tags to your ElastiCache resources, AWS generates a cost allocation
    /// report as a comma-separated value (CSV) file with your usage and costs aggregated
    /// by your tags. You can apply tags that represent business categories (such as cost
    /// centers, application names, or owners) to organize your costs across multiple services.
    /// For more information, see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/Tagging.html">Using
    /// Cost Allocation Tags in Amazon ElastiCache</a> in the <i>ElastiCache User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "ECTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.Tag")]
    [AWSCmdlet("Calls the Amazon ElastiCache AddTagsToResource API operation.", Operation = new[] {"AddTagsToResource"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.Tag",
        "This cmdlet returns a collection of Tag objects.",
        "The service call response (type Amazon.ElastiCache.Model.AddTagsToResourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddECTagCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource to which the tags are to be added,
        /// for example <code>arn:aws:elasticache:us-west-2:0123456789:cluster:myCluster</code>
        /// or <code>arn:aws:elasticache:us-west-2:0123456789:snapshot:mySnapshot</code>. ElastiCache
        /// resources are <i>cluster</i> and <i>snapshot</i>.</para><para>For more information about ARNs, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of cost allocation tags to be added to this resource. A tag is a key-value
        /// pair. A tag key must be accompanied by a tag value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ECTag (AddTagsToResource)"))
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
            
            context.ResourceName = this.ResourceName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
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
            var request = new Amazon.ElastiCache.Model.AddTagsToResourceRequest();
            
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
                object pipelineOutput = response.TagList;
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
        
        private Amazon.ElastiCache.Model.AddTagsToResourceResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.AddTagsToResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "AddTagsToResource");
            try
            {
                #if DESKTOP
                return client.AddTagsToResource(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddTagsToResourceAsync(request);
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
            public System.String ResourceName { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tags { get; set; }
        }
        
    }
}
