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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Executes commands on one or more remote instances.
    /// </summary>
    [Cmdlet("Send", "SSMCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.Command")]
    [AWSCmdlet("Invokes the SendCommand operation against Amazon Simple Systems Management.", Operation = new[] {"SendCommand"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.Command",
        "This cmdlet returns a Command object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.SendCommandResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendSSMCommandCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>User-specified information about the command, such as a brief description of what
        /// the command should do.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter DocumentHash
        /// <summary>
        /// <para>
        /// <para>The Sha256 or Sha1 hash created by the system when the document was created. </para><note><para>Sha1 hashes have been deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DocumentHash { get; set; }
        #endregion
        
        #region Parameter DocumentHashType
        /// <summary>
        /// <para>
        /// <para>Sha256 or Sha1.</para><note><para>Sha1 hashes have been deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentHashType")]
        public Amazon.SimpleSystemsManagement.DocumentHashType DocumentHashType { get; set; }
        #endregion
        
        #region Parameter DocumentName
        /// <summary>
        /// <para>
        /// <para>Required. The name of the SSM document to execute. This can be an SSM public document
        /// or a custom document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DocumentName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>Required. The instance IDs where the command should execute. You can specify a maximum
        /// of 50 IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where command execution responses should be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The directory structure within the S3 bucket where the responses should be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The required and optional parameters specified in the SSM document being executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>If this time is reached and the command has not already started executing, it will
        /// not execute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeoutSeconds")]
        public System.Int32 TimeoutSecond { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SSMCommand (SendCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Comment = this.Comment;
            context.DocumentHash = this.DocumentHash;
            context.DocumentHashType = this.DocumentHashType;
            context.DocumentName = this.DocumentName;
            if (this.InstanceId != null)
            {
                context.InstanceIds = new List<System.String>(this.InstanceId);
            }
            context.OutputS3BucketName = this.OutputS3BucketName;
            context.OutputS3KeyPrefix = this.OutputS3KeyPrefix;
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameters.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Parameters.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("TimeoutSecond"))
                context.TimeoutSeconds = this.TimeoutSecond;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleSystemsManagement.Model.SendCommandRequest();
            
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.DocumentHash != null)
            {
                request.DocumentHash = cmdletContext.DocumentHash;
            }
            if (cmdletContext.DocumentHashType != null)
            {
                request.DocumentHashType = cmdletContext.DocumentHashType;
            }
            if (cmdletContext.DocumentName != null)
            {
                request.DocumentName = cmdletContext.DocumentName;
            }
            if (cmdletContext.InstanceIds != null)
            {
                request.InstanceIds = cmdletContext.InstanceIds;
            }
            if (cmdletContext.OutputS3BucketName != null)
            {
                request.OutputS3BucketName = cmdletContext.OutputS3BucketName;
            }
            if (cmdletContext.OutputS3KeyPrefix != null)
            {
                request.OutputS3KeyPrefix = cmdletContext.OutputS3KeyPrefix;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.TimeoutSeconds != null)
            {
                request.TimeoutSeconds = cmdletContext.TimeoutSeconds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Command;
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
        
        private static Amazon.SimpleSystemsManagement.Model.SendCommandResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.SendCommandRequest request)
        {
            return client.SendCommand(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Comment { get; set; }
            public System.String DocumentHash { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentHashType DocumentHashType { get; set; }
            public System.String DocumentName { get; set; }
            public List<System.String> InstanceIds { get; set; }
            public System.String OutputS3BucketName { get; set; }
            public System.String OutputS3KeyPrefix { get; set; }
            public Dictionary<System.String, List<System.String>> Parameters { get; set; }
            public System.Int32? TimeoutSeconds { get; set; }
        }
        
    }
}
