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
using Amazon.MQ;
using Amazon.MQ.Model;

namespace Amazon.PowerShell.Cmdlets.MQ
{
    /// <summary>
    /// Returns the specified configuration revision for the specified configuration.
    /// </summary>
    [Cmdlet("Get", "MQConfigurationRevision")]
    [OutputType("Amazon.MQ.Model.DescribeConfigurationRevisionResponse")]
    [AWSCmdlet("Calls the Amazon MQ DescribeConfigurationRevision API operation.", Operation = new[] {"DescribeConfigurationRevision"})]
    [AWSCmdletOutput("Amazon.MQ.Model.DescribeConfigurationRevisionResponse",
        "This cmdlet returns a Amazon.MQ.Model.DescribeConfigurationRevisionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMQConfigurationRevisionCmdlet : AmazonMQClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationId
        /// <summary>
        /// <para>
        /// The unique ID that Amazon MQ generates
        /// for the configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationId { get; set; }
        #endregion
        
        #region Parameter ConfigurationRevision
        /// <summary>
        /// <para>
        /// The revision of the configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ConfigurationRevision { get; set; }
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
            
            context.ConfigurationId = this.ConfigurationId;
            context.ConfigurationRevision = this.ConfigurationRevision;
            
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
            var request = new Amazon.MQ.Model.DescribeConfigurationRevisionRequest();
            
            if (cmdletContext.ConfigurationId != null)
            {
                request.ConfigurationId = cmdletContext.ConfigurationId;
            }
            if (cmdletContext.ConfigurationRevision != null)
            {
                request.ConfigurationRevision = cmdletContext.ConfigurationRevision;
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
        
        private Amazon.MQ.Model.DescribeConfigurationRevisionResponse CallAWSServiceOperation(IAmazonMQ client, Amazon.MQ.Model.DescribeConfigurationRevisionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MQ", "DescribeConfigurationRevision");
            try
            {
                #if DESKTOP
                return client.DescribeConfigurationRevision(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeConfigurationRevisionAsync(request);
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
            public System.String ConfigurationId { get; set; }
            public System.String ConfigurationRevision { get; set; }
        }
        
    }
}
