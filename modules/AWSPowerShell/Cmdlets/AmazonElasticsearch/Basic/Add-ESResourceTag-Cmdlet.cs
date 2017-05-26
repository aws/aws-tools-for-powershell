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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Attaches tags to an existing Elasticsearch domain. Tags are a set of case-sensitive
    /// key value pairs. An Elasticsearch domain may have up to 10 tags. See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-managedomains.html#es-managedomains-awsresorcetagging" target="_blank"> Tagging Amazon Elasticsearch Service Domains for more information.</a>
    /// </summary>
    [Cmdlet("Add", "ESResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","Amazon.Elasticsearch.Model.Tag")]
    [AWSCmdlet("Invokes the AddTags operation against Amazon Elasticsearch.", Operation = new[] {"AddTags"}, LegacyAlias="Add-ESTag")]
    [AWSCmdletOutput("None or Amazon.Elasticsearch.Model.Tag",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the TagList parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Elasticsearch.Model.AddTagsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddESResourceTagCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        #region Parameter ARN
        /// <summary>
        /// <para>
        /// <para> Specify the <code>ARN</code> for which you want to add the tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ARN { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// <para> List of <code>Tag</code> that need to be added for the Elasticsearch domain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.Elasticsearch.Model.Tag[] TagList { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the TagList parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TagList", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ESResourceTag (AddTags)"))
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
            
            context.ARN = this.ARN;
            if (this.TagList != null)
            {
                context.TagList = new List<Amazon.Elasticsearch.Model.Tag>(this.TagList);
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
            var request = new Amazon.Elasticsearch.Model.AddTagsRequest();
            
            if (cmdletContext.ARN != null)
            {
                request.ARN = cmdletContext.ARN;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.TagList;
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
        
        private Amazon.Elasticsearch.Model.AddTagsResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.AddTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "AddTags");
            #if DESKTOP
            return client.AddTags(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddTagsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ARN { get; set; }
            public List<Amazon.Elasticsearch.Model.Tag> TagList { get; set; }
        }
        
    }
}
