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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Given a list of identities (email addresses and/or domains), returns the verification
    /// status and (for domain identities) the verification token for each identity.
    /// 
    ///  
    /// <para>
    /// The verification status of an email address is "Pending" until the email address owner
    /// clicks the link within the verification email that Amazon SES sent to that address.
    /// If the email address owner clicks the link within 24 hours, the verification status
    /// of the email address changes to "Success". If the link is not clicked within 24 hours,
    /// the verification status changes to "Failed." In that case, if you still want to verify
    /// the email address, you must restart the verification process from the beginning.
    /// </para><para>
    /// For domain identities, the domain's verification status is "Pending" as Amazon SES
    /// searches for the required TXT record in the DNS settings of the domain. When Amazon
    /// SES detects the record, the domain's verification status changes to "Success". If
    /// Amazon SES is unable to detect the record within 72 hours, the domain's verification
    /// status changes to "Failed." In that case, if you still want to verify the domain,
    /// you must restart the verification process from the beginning.
    /// </para><para>
    /// This operation is throttled at one request per second and can only get verification
    /// attributes for up to 100 identities at a time.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SESIdentityVerificationAttribute")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service GetIdentityVerificationAttributes API operation.", Operation = new[] {"GetIdentityVerificationAttributes"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSESIdentityVerificationAttributeCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>A list of identities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Identities")]
        public System.String[] Identity { get; set; }
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
            
            if (this.Identity != null)
            {
                context.Identities = new List<System.String>(this.Identity);
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
            var request = new Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesRequest();
            
            if (cmdletContext.Identities != null)
            {
                request.Identities = cmdletContext.Identities;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VerificationAttributes;
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
        
        private Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.GetIdentityVerificationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "GetIdentityVerificationAttributes");
            try
            {
                #if DESKTOP
                return client.GetIdentityVerificationAttributes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetIdentityVerificationAttributesAsync(request);
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
            public List<System.String> Identities { get; set; }
        }
        
    }
}
