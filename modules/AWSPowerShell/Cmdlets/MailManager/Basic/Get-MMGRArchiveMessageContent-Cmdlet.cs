/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Returns the textual content of a specific email message stored in the archive. Attachments
    /// are not included.
    /// </summary>
    [Cmdlet("Get", "MMGRArchiveMessageContent")]
    [OutputType("Amazon.MailManager.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager GetArchiveMessageContent API operation.", Operation = new[] {"GetArchiveMessageContent"}, SelectReturnType = typeof(Amazon.MailManager.Model.GetArchiveMessageContentResponse))]
    [AWSCmdletOutput("Amazon.MailManager.Model.MessageBody or Amazon.MailManager.Model.GetArchiveMessageContentResponse",
        "This cmdlet returns an Amazon.MailManager.Model.MessageBody object.",
        "The service call response (type Amazon.MailManager.Model.GetArchiveMessageContentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMMGRArchiveMessageContentCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ArchivedMessageId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the archived email message.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ArchivedMessageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Body'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.GetArchiveMessageContentResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.GetArchiveMessageContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Body";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.GetArchiveMessageContentResponse, GetMMGRArchiveMessageContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArchivedMessageId = this.ArchivedMessageId;
            #if MODULAR
            if (this.ArchivedMessageId == null && ParameterWasBound(nameof(this.ArchivedMessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchivedMessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.MailManager.Model.GetArchiveMessageContentRequest();
            
            if (cmdletContext.ArchivedMessageId != null)
            {
                request.ArchivedMessageId = cmdletContext.ArchivedMessageId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.MailManager.Model.GetArchiveMessageContentResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.GetArchiveMessageContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "GetArchiveMessageContent");
            try
            {
                #if DESKTOP
                return client.GetArchiveMessageContent(request);
                #elif CORECLR
                return client.GetArchiveMessageContentAsync(request).GetAwaiter().GetResult();
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
            public System.String ArchivedMessageId { get; set; }
            public System.Func<Amazon.MailManager.Model.GetArchiveMessageContentResponse, GetMMGRArchiveMessageContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Body;
        }
        
    }
}
