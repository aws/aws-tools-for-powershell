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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The TestRole operation tests the IAM role used to create the pipeline.
    /// 
    ///  
    /// <para>
    /// The <code>TestRole</code> action lets you determine whether the IAM role you are using
    /// has sufficient permissions to let Elastic Transcoder perform tasks associated with
    /// the transcoding process. The action attempts to assume the specified IAM role, checks
    /// read access to the input and output buckets, and tries to send a test notification
    /// to Amazon SNS topics that you specify.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Test", "ETSRole")]
    [OutputType("Amazon.ElasticTranscoder.Model.TestRoleResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Transcoder TestRole API operation.", Operation = new[] {"TestRole"}, SelectReturnType = typeof(Amazon.ElasticTranscoder.Model.TestRoleResponse))]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.TestRoleResponse",
        "This cmdlet returns an Amazon.ElasticTranscoder.Model.TestRoleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("This API is deprecated and will be removed in a future release.")]
    public partial class TestETSRoleCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        #region Parameter InputBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that contains media files to be transcoded. The action attempts
        /// to read from this bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InputBucket { get; set; }
        #endregion
        
        #region Parameter OutputBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that Elastic Transcoder writes transcoded media files to. The
        /// action attempts to read from this bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OutputBucket { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The IAM Amazon Resource Name (ARN) for the role that you want Elastic Transcoder to
        /// test.</para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Topic
        /// <summary>
        /// <para>
        /// <para>The ARNs of one or more Amazon Simple Notification Service (Amazon SNS) topics that
        /// you want the action to send a test notification to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Topics")]
        public System.String[] Topic { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticTranscoder.Model.TestRoleResponse).
        /// Specifying the name of a property of type Amazon.ElasticTranscoder.Model.TestRoleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Role parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Role' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Role' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticTranscoder.Model.TestRoleResponse, TestETSRoleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Role;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InputBucket = this.InputBucket;
            #if MODULAR
            if (this.InputBucket == null && ParameterWasBound(nameof(this.InputBucket)))
            {
                WriteWarning("You are passing $null as a value for parameter InputBucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputBucket = this.OutputBucket;
            #if MODULAR
            if (this.OutputBucket == null && ParameterWasBound(nameof(this.OutputBucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputBucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Topic != null)
            {
                context.Topic = new List<System.String>(this.Topic);
            }
            #if MODULAR
            if (this.Topic == null && ParameterWasBound(nameof(this.Topic)))
            {
                WriteWarning("You are passing $null as a value for parameter Topic which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticTranscoder.Model.TestRoleRequest();
            
            if (cmdletContext.InputBucket != null)
            {
                request.InputBucket = cmdletContext.InputBucket;
            }
            if (cmdletContext.OutputBucket != null)
            {
                request.OutputBucket = cmdletContext.OutputBucket;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Topic != null)
            {
                request.Topics = cmdletContext.Topic;
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
        
        private Amazon.ElasticTranscoder.Model.TestRoleResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.TestRoleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Transcoder", "TestRole");
            try
            {
                #if DESKTOP
                return client.TestRole(request);
                #elif CORECLR
                return client.TestRoleAsync(request).GetAwaiter().GetResult();
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
            public System.String InputBucket { get; set; }
            public System.String OutputBucket { get; set; }
            public System.String Role { get; set; }
            public List<System.String> Topic { get; set; }
            public System.Func<Amazon.ElasticTranscoder.Model.TestRoleResponse, TestETSRoleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
