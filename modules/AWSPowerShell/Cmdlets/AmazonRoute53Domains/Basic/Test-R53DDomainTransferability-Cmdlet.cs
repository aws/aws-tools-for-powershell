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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// Checks whether a domain name can be transferred to Amazon Route 53.
    /// </summary>
    [Cmdlet("Test", "R53DDomainTransferability")]
    [OutputType("Amazon.Route53Domains.Model.DomainTransferability")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains CheckDomainTransferability API operation.", Operation = new[] {"CheckDomainTransferability"})]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainTransferability",
        "This cmdlet returns a DomainTransferability object.",
        "The service call response (type Amazon.Route53Domains.Model.CheckDomainTransferabilityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestR53DDomainTransferabilityCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        #region Parameter AuthCode
        /// <summary>
        /// <para>
        /// <para>If the registrar for the top-level domain (TLD) requires an authorization code to
        /// transfer the domain, the code that you got from the current registrar for the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthCode { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain that you want to transfer to Amazon Route 53.</para><para>Constraints: The domain name can contain only the letters a through z, the numbers
        /// 0 through 9, and hyphen (-). Internationalized Domain Names are not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
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
            
            context.AuthCode = this.AuthCode;
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
            var request = new Amazon.Route53Domains.Model.CheckDomainTransferabilityRequest();
            
            if (cmdletContext.AuthCode != null)
            {
                request.AuthCode = cmdletContext.AuthCode;
            }
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
                object pipelineOutput = response.Transferability;
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
        
        private Amazon.Route53Domains.Model.CheckDomainTransferabilityResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.CheckDomainTransferabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "CheckDomainTransferability");
            try
            {
                #if DESKTOP
                return client.CheckDomainTransferability(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CheckDomainTransferabilityAsync(request);
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
            public System.String AuthCode { get; set; }
            public System.String DomainName { get; set; }
        }
        
    }
}
