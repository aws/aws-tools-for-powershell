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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Decodes additional information about the authorization status of a request from an
    /// encoded message returned in response to an AWS request. 
    /// 
    ///  
    /// <para>
    /// For example, if a user is not authorized to perform an action that he or she has requested,
    /// the request returns a <code>Client.UnauthorizedOperation</code> response (an HTTP
    /// 403 response). Some AWS actions additionally return an encoded message that can provide
    /// details about this authorization failure. 
    /// </para><note> Only certain AWS actions return an encoded authorization message. The documentation
    /// for an individual action indicates whether that action returns an encoded message
    /// in addition to returning an HTTP code. </note><para>
    /// The message is encoded because the details of the authorization status can constitute
    /// privileged information that the user who requested the action should not see. To decode
    /// an authorization status message, a user must be granted permissions via an IAM policy
    /// to request the <code>DecodeAuthorizationMessage</code> (<code>sts:DecodeAuthorizationMessage</code>)
    /// action. 
    /// </para><para>
    /// The decoded message includes the following type of information: 
    /// </para><ul><li>Whether the request was denied due to an explicit deny or due to the absence
    /// of an explicit allow. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/AccessPolicyLanguage_EvaluationLogic.html#policy-eval-denyallow">Determining
    /// Whether a Request is Allowed or Denied</a> in <i>Using IAM</i>. </li><li>The principal
    /// who made the request.</li><li>The requested action.</li><li>The requested resource.</li><li>The values of condition keys in the context of the user's request.</li></ul>
    /// </summary>
    [Cmdlet("Convert", "STSAuthorizationMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the DecodeAuthorizationMessage operation against AWS Security Token Service.", Operation = new[] {"DecodeAuthorizationMessage"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type DecodeAuthorizationMessageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ConvertSTSAuthorizationMessageCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The encoded message that was returned with the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String EncodedMessage { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EncodedMessage", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-STSAuthorizationMessage (DecodeAuthorizationMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.EncodedMessage = this.EncodedMessage;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DecodeAuthorizationMessageRequest();
            
            if (cmdletContext.EncodedMessage != null)
            {
                request.EncodedMessage = cmdletContext.EncodedMessage;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DecodeAuthorizationMessage(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DecodedMessage;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String EncodedMessage { get; set; }
        }
        
    }
}
