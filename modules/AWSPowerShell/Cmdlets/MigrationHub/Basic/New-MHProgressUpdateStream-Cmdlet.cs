/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Creates a progress update stream which is an AWS resource used for access control
    /// as well as a namespace for migration task names that is implicitly linked to your
    /// AWS account. It must uniquely identify the migration tool as it is used for all updates
    /// made by the tool; however, it does not need to be unique for each AWS account because
    /// it is scoped to the AWS account.
    /// </summary>
    [Cmdlet("New", "MHProgressUpdateStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Migration Hub CreateProgressUpdateStream API operation.", Operation = new[] {"CreateProgressUpdateStream"}, SelectReturnType = typeof(Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse))]
    [AWSCmdletOutput("None or Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewMHProgressUpdateStreamCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Optional boolean flag to indicate whether any effect should take place. Used to test
        /// if the caller has permission to make the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the ProgressUpdateStream. <i>Do not store personal data in this field.</i></para>
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
        public System.String ProgressUpdateStreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProgressUpdateStreamName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProgressUpdateStreamName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProgressUpdateStreamName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProgressUpdateStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MHProgressUpdateStream (CreateProgressUpdateStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse, NewMHProgressUpdateStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProgressUpdateStreamName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.ProgressUpdateStreamName = this.ProgressUpdateStreamName;
            #if MODULAR
            if (this.ProgressUpdateStreamName == null && ParameterWasBound(nameof(this.ProgressUpdateStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgressUpdateStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHub.Model.CreateProgressUpdateStreamRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ProgressUpdateStreamName != null)
            {
                request.ProgressUpdateStreamName = cmdletContext.ProgressUpdateStreamName;
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
        
        private Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.CreateProgressUpdateStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "CreateProgressUpdateStream");
            try
            {
                #if DESKTOP
                return client.CreateProgressUpdateStream(request);
                #elif CORECLR
                return client.CreateProgressUpdateStreamAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String ProgressUpdateStreamName { get; set; }
            public System.Func<Amazon.MigrationHub.Model.CreateProgressUpdateStreamResponse, NewMHProgressUpdateStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
