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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Generates a random password of the specified complexity. This operation is intended
    /// for use in the Lambda rotation function. Per best practice, we recommend that you
    /// specify the maximum length and include every character type that the system you are
    /// generating a password for can support.
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:GetRandomPassword
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "SECRandomPassword")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Secrets Manager GetRandomPassword API operation.", Operation = new[] {"GetRandomPassword"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.GetRandomPasswordResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecretsManager.Model.GetRandomPasswordResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecretsManager.Model.GetRandomPasswordResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSECRandomPasswordCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ExcludeCharacter
        /// <summary>
        /// <para>
        /// <para>A string that includes characters that should not be included in the generated password.
        /// The default is that all characters from the included sets can be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeCharacters")]
        public System.String ExcludeCharacter { get; set; }
        #endregion
        
        #region Parameter ExcludeLowercase
        /// <summary>
        /// <para>
        /// <para>Specifies that the generated password should not include lowercase letters. The default
        /// if you do not include this switch parameter is that lowercase letters can be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExcludeLowercase { get; set; }
        #endregion
        
        #region Parameter ExcludeNumber
        /// <summary>
        /// <para>
        /// <para>Specifies that the generated password should not include digits. The default if you
        /// do not include this switch parameter is that digits can be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeNumbers")]
        public System.Boolean? ExcludeNumber { get; set; }
        #endregion
        
        #region Parameter ExcludePunctuation
        /// <summary>
        /// <para>
        /// <para>Specifies that the generated password should not include punctuation characters. The
        /// default if you do not include this switch parameter is that punctuation characters
        /// can be included.</para><para>The following are the punctuation characters that <i>can</i> be included in the generated
        /// password if you don't explicitly exclude them with <code>ExcludeCharacters</code>
        /// or <code>ExcludePunctuation</code>:</para><para><code>! " # $ % &amp; ' ( ) * + , - . / : ; &lt; = &gt; ? @ [ \ ] ^ _ ` { | } ~</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExcludePunctuation { get; set; }
        #endregion
        
        #region Parameter ExcludeUppercase
        /// <summary>
        /// <para>
        /// <para>Specifies that the generated password should not include uppercase letters. The default
        /// if you do not include this switch parameter is that uppercase letters can be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExcludeUppercase { get; set; }
        #endregion
        
        #region Parameter IncludeSpace
        /// <summary>
        /// <para>
        /// <para>Specifies that the generated password can include the space character. The default
        /// if you do not include this switch parameter is that the space character is not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeSpace { get; set; }
        #endregion
        
        #region Parameter PasswordLength
        /// <summary>
        /// <para>
        /// <para>The desired length of the generated password. The default value if you do not include
        /// this parameter is 32 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PasswordLength { get; set; }
        #endregion
        
        #region Parameter RequireEachIncludedType
        /// <summary>
        /// <para>
        /// <para>A boolean value that specifies whether the generated password must include at least
        /// one of every allowed character type. The default value is <code>True</code> and the
        /// operation requires at least one of every character type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RequireEachIncludedType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RandomPassword'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.GetRandomPasswordResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.GetRandomPasswordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RandomPassword";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.GetRandomPasswordResponse, GetSECRandomPasswordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExcludeCharacter = this.ExcludeCharacter;
            context.ExcludeLowercase = this.ExcludeLowercase;
            context.ExcludeNumber = this.ExcludeNumber;
            context.ExcludePunctuation = this.ExcludePunctuation;
            context.ExcludeUppercase = this.ExcludeUppercase;
            context.IncludeSpace = this.IncludeSpace;
            context.PasswordLength = this.PasswordLength;
            context.RequireEachIncludedType = this.RequireEachIncludedType;
            
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
            var request = new Amazon.SecretsManager.Model.GetRandomPasswordRequest();
            
            if (cmdletContext.ExcludeCharacter != null)
            {
                request.ExcludeCharacters = cmdletContext.ExcludeCharacter;
            }
            if (cmdletContext.ExcludeLowercase != null)
            {
                request.ExcludeLowercase = cmdletContext.ExcludeLowercase.Value;
            }
            if (cmdletContext.ExcludeNumber != null)
            {
                request.ExcludeNumbers = cmdletContext.ExcludeNumber.Value;
            }
            if (cmdletContext.ExcludePunctuation != null)
            {
                request.ExcludePunctuation = cmdletContext.ExcludePunctuation.Value;
            }
            if (cmdletContext.ExcludeUppercase != null)
            {
                request.ExcludeUppercase = cmdletContext.ExcludeUppercase.Value;
            }
            if (cmdletContext.IncludeSpace != null)
            {
                request.IncludeSpace = cmdletContext.IncludeSpace.Value;
            }
            if (cmdletContext.PasswordLength != null)
            {
                request.PasswordLength = cmdletContext.PasswordLength.Value;
            }
            if (cmdletContext.RequireEachIncludedType != null)
            {
                request.RequireEachIncludedType = cmdletContext.RequireEachIncludedType.Value;
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
        
        private Amazon.SecretsManager.Model.GetRandomPasswordResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.GetRandomPasswordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "GetRandomPassword");
            try
            {
                #if DESKTOP
                return client.GetRandomPassword(request);
                #elif CORECLR
                return client.GetRandomPasswordAsync(request).GetAwaiter().GetResult();
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
            public System.String ExcludeCharacter { get; set; }
            public System.Boolean? ExcludeLowercase { get; set; }
            public System.Boolean? ExcludeNumber { get; set; }
            public System.Boolean? ExcludePunctuation { get; set; }
            public System.Boolean? ExcludeUppercase { get; set; }
            public System.Boolean? IncludeSpace { get; set; }
            public System.Int64? PasswordLength { get; set; }
            public System.Boolean? RequireEachIncludedType { get; set; }
            public System.Func<Amazon.SecretsManager.Model.GetRandomPasswordResponse, GetSECRandomPasswordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RandomPassword;
        }
        
    }
}
