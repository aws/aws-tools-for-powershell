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
using Amazon.Cloud9;
using Amazon.Cloud9.Model;

namespace Amazon.PowerShell.Cmdlets.C9
{
    /// <summary>
    /// Creates an AWS Cloud9 development environment, launches an Amazon Elastic Compute
    /// Cloud (Amazon EC2) instance, and then connects from the instance to the environment.
    /// </summary>
    [Cmdlet("New", "C9EnvironmentEC2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cloud9 CreateEnvironmentEC2 API operation.", Operation = new[] {"CreateEnvironmentEC2"}, SelectReturnType = typeof(Amazon.Cloud9.Model.CreateEnvironmentEC2Response))]
    [AWSCmdletOutput("System.String or Amazon.Cloud9.Model.CreateEnvironmentEC2Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Cloud9.Model.CreateEnvironmentEC2Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewC9EnvironmentEC2Cmdlet : AmazonCloud9ClientCmdlet, IExecutor
    {
        
        #region Parameter AutomaticStopTimeMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes until the running instance is shut down after the environment
        /// has last been used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutomaticStopTimeMinutes")]
        public System.Int32? AutomaticStopTimeMinute { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive string that helps AWS Cloud9 to ensure this operation completes
        /// no more than one time.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Client
        /// Tokens</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ConnectionType
        /// <summary>
        /// <para>
        /// <para>The connection type used for connecting to an Amazon EC2 environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Cloud9.ConnectionType")]
        public Amazon.Cloud9.ConnectionType ConnectionType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the environment to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The type of instance to connect to the environment (for example, <code>t2.micro</code>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the environment to create.</para><para>This name is visible to other AWS IAM users in the same AWS account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OwnerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the environment owner. This ARN can be the ARN of
        /// any AWS IAM principal. If this value is not specified, the ARN defaults to this environment's
        /// creator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in Amazon VPC that AWS Cloud9 will use to communicate with the
        /// Amazon EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs that will be associated with the new AWS Cloud9 development
        /// environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Cloud9.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Cloud9.Model.CreateEnvironmentEC2Response).
        /// Specifying the name of a property of type Amazon.Cloud9.Model.CreateEnvironmentEC2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-C9EnvironmentEC2 (CreateEnvironmentEC2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Cloud9.Model.CreateEnvironmentEC2Response, NewC9EnvironmentEC2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutomaticStopTimeMinute = this.AutomaticStopTimeMinute;
            context.ClientRequestToken = this.ClientRequestToken;
            context.ConnectionType = this.ConnectionType;
            context.Description = this.Description;
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwnerArn = this.OwnerArn;
            context.SubnetId = this.SubnetId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Cloud9.Model.Tag>(this.Tag);
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
            var request = new Amazon.Cloud9.Model.CreateEnvironmentEC2Request();
            
            if (cmdletContext.AutomaticStopTimeMinute != null)
            {
                request.AutomaticStopTimeMinutes = cmdletContext.AutomaticStopTimeMinute.Value;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ConnectionType != null)
            {
                request.ConnectionType = cmdletContext.ConnectionType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OwnerArn != null)
            {
                request.OwnerArn = cmdletContext.OwnerArn;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Cloud9.Model.CreateEnvironmentEC2Response CallAWSServiceOperation(IAmazonCloud9 client, Amazon.Cloud9.Model.CreateEnvironmentEC2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud9", "CreateEnvironmentEC2");
            try
            {
                #if DESKTOP
                return client.CreateEnvironmentEC2(request);
                #elif CORECLR
                return client.CreateEnvironmentEC2Async(request).GetAwaiter().GetResult();
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
            public System.Int32? AutomaticStopTimeMinute { get; set; }
            public System.String ClientRequestToken { get; set; }
            public Amazon.Cloud9.ConnectionType ConnectionType { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceType { get; set; }
            public System.String Name { get; set; }
            public System.String OwnerArn { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.Cloud9.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Cloud9.Model.CreateEnvironmentEC2Response, NewC9EnvironmentEC2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentId;
        }
        
    }
}
