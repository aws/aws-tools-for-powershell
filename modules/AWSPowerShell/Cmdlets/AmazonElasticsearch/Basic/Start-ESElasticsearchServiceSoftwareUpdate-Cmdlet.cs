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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Schedules a service software update for an Amazon ES domain.
    /// </summary>
    [Cmdlet("Start", "ESElasticsearchServiceSoftwareUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.ServiceSoftwareOptions")]
    [AWSCmdlet("Calls the Amazon Elasticsearch StartElasticsearchServiceSoftwareUpdate API operation.", Operation = new[] {"StartElasticsearchServiceSoftwareUpdate"})]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.ServiceSoftwareOptions",
        "This cmdlet returns a ServiceSoftwareOptions object.",
        "The service call response (type Amazon.Elasticsearch.Model.StartElasticsearchServiceSoftwareUpdateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartESElasticsearchServiceSoftwareUpdateCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to update to the latest service software.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ESElasticsearchServiceSoftwareUpdate (StartElasticsearchServiceSoftwareUpdate)"))
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
            
            context.DomainName = this.DomainName;
            
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
            var request = new Amazon.Elasticsearch.Model.StartElasticsearchServiceSoftwareUpdateRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ServiceSoftwareOptions;
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
        
        private Amazon.Elasticsearch.Model.StartElasticsearchServiceSoftwareUpdateResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.StartElasticsearchServiceSoftwareUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "StartElasticsearchServiceSoftwareUpdate");
            try
            {
                #if DESKTOP
                return client.StartElasticsearchServiceSoftwareUpdate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartElasticsearchServiceSoftwareUpdateAsync(request);
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
            public System.String DomainName { get; set; }
        }
        
    }
}
