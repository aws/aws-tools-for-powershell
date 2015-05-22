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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Creates a display name for a customer master key. An alias can be used to identify
    /// a key and should be unique. The console enforces a one-to-one mapping between the
    /// alias and a key. An alias name can contain only alphanumeric characters, forward slashes
    /// (/), underscores (_), and dashes (-). An alias must start with the word "alias" followed
    /// by a forward slash (alias/). An alias that begins with "aws" after the forward slash
    /// (alias/aws...) is reserved by Amazon Web Services (AWS). 
    /// 
    ///  
    /// <para>
    /// To associate an alias with a different key, call <a>UpdateAlias</a>.
    /// </para><para>
    /// Note that you cannot create or update an alias that represents a key in another account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateAlias operation against AWS Key Management Service.", Operation = new[] {"CreateAlias"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the TargetKeyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type CreateAliasResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewKMSAliasCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>String that contains the display name. The name must start with the word "alias" followed
        /// by a forward slash (alias/). Aliases that begin with "alias/AWS" are reserved. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AliasName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An identifier of the key for which you are creating the alias. This value cannot be
        /// another alias but can be a globally unique identifier or a fully specified ARN to
        /// a key. <ul><li>Key ARN Example - arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</li><li>Globally Unique Key ID Example - 12345678-1234-1234-1234-123456789012</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String TargetKeyId { get; set; }
        
        /// <summary>
        /// Returns the value passed to the TargetKeyId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetKeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSAlias (CreateAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AliasName = this.AliasName;
            context.TargetKeyId = this.TargetKeyId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateAliasRequest();
            
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
            }
            if (cmdletContext.TargetKeyId != null)
            {
                request.TargetKeyId = cmdletContext.TargetKeyId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateAlias(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.TargetKeyId;
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
            public String AliasName { get; set; }
            public String TargetKeyId { get; set; }
        }
        
    }
}
