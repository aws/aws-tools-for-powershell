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
using Amazon.WorkLink;
using Amazon.WorkLink.Model;

namespace Amazon.PowerShell.Cmdlets.WL
{
    /// <summary>
    /// Provides information about the certificate authority.
    /// </summary>
    [Cmdlet("Get", "WLWebsiteCertificateAuthority")]
    [OutputType("Amazon.WorkLink.Model.DescribeWebsiteCertificateAuthorityResponse")]
    [AWSCmdlet("Calls the Amazon WorkLink DescribeWebsiteCertificateAuthority API operation.", Operation = new[] {"DescribeWebsiteCertificateAuthority"})]
    [AWSCmdletOutput("Amazon.WorkLink.Model.DescribeWebsiteCertificateAuthorityResponse",
        "This cmdlet returns a Amazon.WorkLink.Model.DescribeWebsiteCertificateAuthorityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetWLWebsiteCertificateAuthorityCmdlet : AmazonWorkLinkClientCmdlet, IExecutor
    {
        
        #region Parameter FleetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetArn { get; set; }
        #endregion
        
        #region Parameter WebsiteCaId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the certificate authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WebsiteCaId { get; set; }
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
            
            context.FleetArn = this.FleetArn;
            context.WebsiteCaId = this.WebsiteCaId;
            
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
            var request = new Amazon.WorkLink.Model.DescribeWebsiteCertificateAuthorityRequest();
            
            if (cmdletContext.FleetArn != null)
            {
                request.FleetArn = cmdletContext.FleetArn;
            }
            if (cmdletContext.WebsiteCaId != null)
            {
                request.WebsiteCaId = cmdletContext.WebsiteCaId;
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
        
        private Amazon.WorkLink.Model.DescribeWebsiteCertificateAuthorityResponse CallAWSServiceOperation(IAmazonWorkLink client, Amazon.WorkLink.Model.DescribeWebsiteCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkLink", "DescribeWebsiteCertificateAuthority");
            try
            {
                #if DESKTOP
                return client.DescribeWebsiteCertificateAuthority(request);
                #elif CORECLR
                return client.DescribeWebsiteCertificateAuthorityAsync(request).GetAwaiter().GetResult();
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
            public System.String FleetArn { get; set; }
            public System.String WebsiteCaId { get; set; }
        }
        
    }
}
