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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Returns a quote and exchange information for exchanging one or more specified Convertible
    /// Reserved Instances for a new Convertible Reserved Instance. If the exchange cannot
    /// be performed, the reason is returned in the response. Use <a>AcceptReservedInstancesExchangeQuote</a>
    /// to perform the exchange.
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesExchangeQuote")]
    [OutputType("Amazon.EC2.Model.GetReservedInstancesExchangeQuoteResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud GetReservedInstancesExchangeQuote API operation.", Operation = new[] {"GetReservedInstancesExchangeQuote"})]
    [AWSCmdletOutput("Amazon.EC2.Model.GetReservedInstancesExchangeQuoteResponse",
        "This cmdlet returns a Amazon.EC2.Model.GetReservedInstancesExchangeQuoteResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ReservedInstancesExchangeQuoteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ReservedInstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Convertible Reserved Instances to exchange.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ReservedInstanceIds")]
        public System.String[] ReservedInstanceId { get; set; }
        #endregion
        
        #region Parameter TargetConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration of the target Convertible Reserved Instance to exchange for your
        /// current Convertible Reserved Instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetConfigurations")]
        public Amazon.EC2.Model.TargetConfigurationRequest[] TargetConfiguration { get; set; }
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
            
            if (this.ReservedInstanceId != null)
            {
                context.ReservedInstanceIds = new List<System.String>(this.ReservedInstanceId);
            }
            if (this.TargetConfiguration != null)
            {
                context.TargetConfigurations = new List<Amazon.EC2.Model.TargetConfigurationRequest>(this.TargetConfiguration);
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
            var request = new Amazon.EC2.Model.GetReservedInstancesExchangeQuoteRequest();
            
            if (cmdletContext.ReservedInstanceIds != null)
            {
                request.ReservedInstanceIds = cmdletContext.ReservedInstanceIds;
            }
            if (cmdletContext.TargetConfigurations != null)
            {
                request.TargetConfigurations = cmdletContext.TargetConfigurations;
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
        
        private Amazon.EC2.Model.GetReservedInstancesExchangeQuoteResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetReservedInstancesExchangeQuoteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "GetReservedInstancesExchangeQuote");
            try
            {
                #if DESKTOP
                return client.GetReservedInstancesExchangeQuote(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetReservedInstancesExchangeQuoteAsync(request);
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
            public List<System.String> ReservedInstanceIds { get; set; }
            public List<Amazon.EC2.Model.TargetConfigurationRequest> TargetConfigurations { get; set; }
        }
        
    }
}
