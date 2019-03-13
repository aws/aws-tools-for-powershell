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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the current configuration items for resources that are present in your AWS
    /// Config aggregator. The operation also returns a list of resources that are not processed
    /// in the current request. If there are no unprocessed resources, the operation returns
    /// an empty <code>unprocessedResourceIdentifiers</code> list. 
    /// 
    ///  <note><ul><li><para>
    /// The API does not return results for deleted resources.
    /// </para></li><li><para>
    ///  The API does not return tags and relationships.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "CFGAggregateResourceConfigBatch")]
    [OutputType("Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse")]
    [AWSCmdlet("Calls the AWS Config BatchGetAggregateResourceConfig API operation.", Operation = new[] {"BatchGetAggregateResourceConfig"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse",
        "This cmdlet returns a Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGAggregateResourceConfigBatchCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>A list of aggregate ResourceIdentifiers objects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceIdentifiers")]
        public Amazon.ConfigService.Model.AggregateResourceIdentifier[] ResourceIdentifier { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            if (this.ResourceIdentifier != null)
            {
                context.ResourceIdentifiers = new List<Amazon.ConfigService.Model.AggregateResourceIdentifier>(this.ResourceIdentifier);
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
            var request = new Amazon.ConfigService.Model.BatchGetAggregateResourceConfigRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            if (cmdletContext.ResourceIdentifiers != null)
            {
                request.ResourceIdentifiers = cmdletContext.ResourceIdentifiers;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ConfigService.Model.BatchGetAggregateResourceConfigResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.BatchGetAggregateResourceConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "BatchGetAggregateResourceConfig");
            try
            {
                #if DESKTOP
                return client.BatchGetAggregateResourceConfig(request);
                #elif CORECLR
                return client.BatchGetAggregateResourceConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationAggregatorName { get; set; }
            public List<Amazon.ConfigService.Model.AggregateResourceIdentifier> ResourceIdentifiers { get; set; }
        }
        
    }
}
