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
    /// Creates a conditional forwarder associated with your AWS directory. Conditional forwarders
    /// are required in order to set up a trust relationship with another domain. The conditional
    /// forwarder points to the trusted domain.
    /// </summary>
    [Cmdlet("New", "DSConditionalForwarder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Directory Service CreateConditionalForwarder API operation.", Operation = new[] {"CreateConditionalForwarder"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DirectoryId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DirectoryService.Model.CreateConditionalForwarderResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSConditionalForwarderCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The directory ID of the AWS directory for which you are creating the conditional forwarder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter DnsIpAddr
        /// <summary>
        /// <para>
        /// <para>The IP addresses of the remote DNS server associated with RemoteDomainName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DnsIpAddrs")]
        public System.String[] DnsIpAddr { get; set; }
        #endregion
        
        #region Parameter RemoteDomainName
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name (FQDN) of the remote domain with which you will set
        /// up a trust relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RemoteDomainName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DirectoryId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSConditionalForwarder (CreateConditionalForwarder)"))
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
            
            context.DirectoryId = this.DirectoryId;
            if (this.DnsIpAddr != null)
            {
                context.DnsIpAddrs = new List<System.String>(this.DnsIpAddr);
            }
            context.RemoteDomainName = this.RemoteDomainName;
            
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
            var request = new Amazon.DirectoryService.Model.CreateConditionalForwarderRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.DnsIpAddrs != null)
            {
                request.DnsIpAddrs = cmdletContext.DnsIpAddrs;
            }
            if (cmdletContext.RemoteDomainName != null)
            {
                request.RemoteDomainName = cmdletContext.RemoteDomainName;
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
                    pipelineOutput = this.DirectoryId;
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
        
        private Amazon.DirectoryService.Model.CreateConditionalForwarderResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.CreateConditionalForwarderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "CreateConditionalForwarder");
            try
            {
                #if DESKTOP
                return client.CreateConditionalForwarder(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateConditionalForwarderAsync(request);
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
            public List<System.String> DnsIpAddrs { get; set; }
            public System.String RemoteDomainName { get; set; }
        }
        
    }
}
