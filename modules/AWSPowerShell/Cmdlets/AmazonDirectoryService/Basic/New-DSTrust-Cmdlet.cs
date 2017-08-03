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
    /// AWS Directory Service for Microsoft Active Directory allows you to configure trust
    /// relationships. For example, you can establish a trust between your Microsoft AD in
    /// the AWS cloud, and your existing on-premises Microsoft Active Directory. This would
    /// allow you to provide users and groups access to resources in either domain, with a
    /// single set of credentials.
    /// 
    ///  
    /// <para>
    /// This action initiates the creation of the AWS side of a trust relationship between
    /// a Microsoft AD in the AWS cloud and an external domain.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSTrust", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateTrust operation against AWS Directory Service.", Operation = new[] {"CreateTrust"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DirectoryService.Model.CreateTrustResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSTrustCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConditionalForwarderIpAddr
        /// <summary>
        /// <para>
        /// <para>The IP addresses of the remote DNS server associated with RemoteDomainName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConditionalForwarderIpAddrs")]
        public System.String[] ConditionalForwarderIpAddr { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The Directory ID of the Microsoft AD in the AWS cloud for which to establish the trust
        /// relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter RemoteDomainName
        /// <summary>
        /// <para>
        /// <para>The Fully Qualified Domain Name (FQDN) of the external domain for which to create
        /// the trust relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RemoteDomainName { get; set; }
        #endregion
        
        #region Parameter TrustDirection
        /// <summary>
        /// <para>
        /// <para>The direction of the trust relationship.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectoryService.TrustDirection")]
        public Amazon.DirectoryService.TrustDirection TrustDirection { get; set; }
        #endregion
        
        #region Parameter TrustPassword
        /// <summary>
        /// <para>
        /// <para>The trust password. The must be the same password that was used when creating the
        /// trust relationship on the external domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrustPassword { get; set; }
        #endregion
        
        #region Parameter TrustType
        /// <summary>
        /// <para>
        /// <para>The trust relationship type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectoryService.TrustType")]
        public Amazon.DirectoryService.TrustType TrustType { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSTrust (CreateTrust)"))
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
            
            if (this.ConditionalForwarderIpAddr != null)
            {
                context.ConditionalForwarderIpAddrs = new List<System.String>(this.ConditionalForwarderIpAddr);
            }
            context.DirectoryId = this.DirectoryId;
            context.RemoteDomainName = this.RemoteDomainName;
            context.TrustDirection = this.TrustDirection;
            context.TrustPassword = this.TrustPassword;
            context.TrustType = this.TrustType;
            
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
            var request = new Amazon.DirectoryService.Model.CreateTrustRequest();
            
            if (cmdletContext.ConditionalForwarderIpAddrs != null)
            {
                request.ConditionalForwarderIpAddrs = cmdletContext.ConditionalForwarderIpAddrs;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.RemoteDomainName != null)
            {
                request.RemoteDomainName = cmdletContext.RemoteDomainName;
            }
            if (cmdletContext.TrustDirection != null)
            {
                request.TrustDirection = cmdletContext.TrustDirection;
            }
            if (cmdletContext.TrustPassword != null)
            {
                request.TrustPassword = cmdletContext.TrustPassword;
            }
            if (cmdletContext.TrustType != null)
            {
                request.TrustType = cmdletContext.TrustType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TrustId;
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
        
        private Amazon.DirectoryService.Model.CreateTrustResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.CreateTrustRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "CreateTrust");
            #if DESKTOP
            return client.CreateTrust(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateTrustAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> ConditionalForwarderIpAddrs { get; set; }
            public System.String DirectoryId { get; set; }
            public System.String RemoteDomainName { get; set; }
            public Amazon.DirectoryService.TrustDirection TrustDirection { get; set; }
            public System.String TrustPassword { get; set; }
            public Amazon.DirectoryService.TrustType TrustType { get; set; }
        }
        
    }
}
