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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Attaches one or more tags, each consisting of a key name and a value, to the specified
    /// secret. Tags are part of the secret's overall metadata, and are not associated with
    /// any specific version of the secret. This operation only appends tags to the existing
    /// list of tags. To remove tags, you must use <a>UntagResource</a>.
    /// 
    ///  
    /// <para>
    /// The following basic restrictions apply to tags:
    /// </para><ul><li><para>
    /// Maximum number of tags per secret—50
    /// </para></li><li><para>
    /// Maximum key length—127 Unicode characters in UTF-8
    /// </para></li><li><para>
    /// Maximum value length—255 Unicode characters in UTF-8
    /// </para></li><li><para>
    /// Tag keys and values are case sensitive.
    /// </para></li><li><para>
    /// Do not use the <code>aws:</code> prefix in your tag names or values because it is
    /// reserved for AWS use. You can't edit or delete tag names or values with this prefix.
    /// Tags with this prefix do not count against your tags per secret limit.
    /// </para></li><li><para>
    /// If your tagging schema will be used across multiple services and resources, remember
    /// that other services might have restrictions on allowed characters. Generally allowed
    /// characters are: letters, spaces, and numbers representable in UTF-8, plus the following
    /// special characters: + - = . _ : / @.
    /// </para></li></ul><important><para>
    /// If you use tags as part of your security strategy, then adding or removing a tag can
    /// change permissions. If successfully completing this operation would result in you
    /// losing your permissions for this secret, then the operation is blocked and returns
    /// an Access Denied error.
    /// </para></important><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:TagResource
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To remove one or more tags from the collection attached to a secret, use <a>UntagResource</a>.
    /// </para></li><li><para>
    /// To view the list of tags attached to a secret, use <a>DescribeSecret</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Add", "SECResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Secrets Manager TagResource API operation.", Operation = new[] {"TagResource"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the SecretId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SecretsManager.Model.TagResourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddSECResourceTagCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>The identifier for the secret that you want to attach tags to. You can specify either
        /// the Amazon Resource Name (ARN) or the friendly name of the secret.</para><note><para>If you specify an ARN, we generally recommend that you specify a complete ARN. You
        /// can specify a partial ARN too—for example, if you don’t include the final hyphen and
        /// six random characters that Secrets Manager adds at the end of the ARN when you created
        /// the secret. A partial ARN match can work as long as it uniquely matches only one secret.
        /// However, if your secret has a name that ends in a hyphen followed by six characters
        /// (before Secrets Manager adds the hyphen and six characters to the ARN) and you try
        /// to use that as a partial ARN, then those characters cause Secrets Manager to assume
        /// that you’re specifying a complete ARN. This confusion can cause unexpected results.
        /// To avoid this situation, we recommend that you don’t create secret names that end
        /// with a hyphen followed by six characters.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the secret. Each element in the list consists of a <code>Key</code>
        /// and a <code>Value</code>.</para><para>This parameter to the API requires a JSON text string argument. For information on
        /// how to format a JSON parameter for the various command line tool environments, see
        /// <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a> in the <i>AWS CLI User Guide</i>. For the AWS CLI, you can
        /// also use the syntax: <code>--Tags Key="Key1",Value="Value1",Key="Key2",Value="Value2"[,…]</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SecretsManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the SecretId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SecretId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SECResourceTag (TagResource)"))
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
            
            context.SecretId = this.SecretId;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SecretsManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.SecretsManager.Model.TagResourceRequest();
            
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
                    pipelineOutput = this.SecretId;
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
        
        private Amazon.SecretsManager.Model.TagResourceResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.TagResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "TagResource");
            try
            {
                #if DESKTOP
                return client.TagResource(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TagResourceAsync(request);
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
            public System.String SecretId { get; set; }
            public List<Amazon.SecretsManager.Model.Tag> Tags { get; set; }
        }
        
    }
}
