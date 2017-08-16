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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Obtains information about the conditional forwarders for this account.
    /// 
    ///  
    /// <para>
    /// If no input parameters are provided for RemoteDomainNames, this request describes
    /// all conditional forwarders for the specified directory ID.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DSConditionalForwarder")]
    [OutputType("Amazon.DirectoryService.Model.ConditionalForwarder")]
    [AWSCmdlet("Invokes the DescribeConditionalForwarders operation against AWS Directory Service.", Operation = new[] {"DescribeConditionalForwarders"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.ConditionalForwarder",
        "This cmdlet returns a collection of ConditionalForwarder objects.",
        "The service call response (type Amazon.DirectoryService.Model.DescribeConditionalForwardersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDSConditionalForwarderCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The directory ID for which to get the list of associated conditional forwarders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter RemoteDomainName
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain names (FQDN) of the remote domains for which to get the
        /// list of associated conditional forwarders. If this member is null, all conditional
        /// forwarders are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoteDomainNames")]
        public System.String[] RemoteDomainName { get; set; }
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
            
            context.DirectoryId = this.DirectoryId;
            if (this.RemoteDomainName != null)
            {
                context.RemoteDomainNames = new List<System.String>(this.RemoteDomainName);
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
            var request = new Amazon.DirectoryService.Model.DescribeConditionalForwardersRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.RemoteDomainNames != null)
            {
                request.RemoteDomainNames = cmdletContext.RemoteDomainNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConditionalForwarders;
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
        
        private Amazon.DirectoryService.Model.DescribeConditionalForwardersResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.DescribeConditionalForwardersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "DescribeConditionalForwarders");
            try
            {
                #if DESKTOP
                return client.DescribeConditionalForwarders(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeConditionalForwardersAsync(request);
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
            public System.String DirectoryId { get; set; }
            public List<System.String> RemoteDomainNames { get; set; }
        }
        
    }
}
