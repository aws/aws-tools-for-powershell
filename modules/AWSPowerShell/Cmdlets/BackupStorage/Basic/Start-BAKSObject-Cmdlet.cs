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
using Amazon.BackupStorage;
using Amazon.BackupStorage.Model;

namespace Amazon.PowerShell.Cmdlets.BAKS
{
    /// <summary>
    /// Start upload containing one or many chunks.
    /// </summary>
    [Cmdlet("Start", "BAKSObject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Backup Storage StartObject API operation.", Operation = new[] {"StartObject"}, SelectReturnType = typeof(Amazon.BackupStorage.Model.StartObjectResponse))]
    [AWSCmdletOutput("System.String or Amazon.BackupStorage.Model.StartObjectResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BackupStorage.Model.StartObjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartBAKSObjectCmdlet : AmazonBackupStorageClientCmdlet, IExecutor
    {
        
        #region Parameter BackupJobId
        /// <summary>
        /// <para>
        /// Backup job Id for the in-progress backup
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
        public System.String BackupJobId { get; set; }
        #endregion
        
        #region Parameter ObjectName
        /// <summary>
        /// <para>
        /// Name for the object.
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
        public System.String ObjectName { get; set; }
        #endregion
        
        #region Parameter ThrowOnDuplicate
        /// <summary>
        /// <para>
        /// Throw an exception if Object name is
        /// already exist.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ThrowOnDuplicate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UploadId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupStorage.Model.StartObjectResponse).
        /// Specifying the name of a property of type Amazon.BackupStorage.Model.StartObjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UploadId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ObjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ObjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ObjectName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ObjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKSObject (StartObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupStorage.Model.StartObjectResponse, StartBAKSObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ObjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupJobId = this.BackupJobId;
            #if MODULAR
            if (this.BackupJobId == null && ParameterWasBound(nameof(this.BackupJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectName = this.ObjectName;
            #if MODULAR
            if (this.ObjectName == null && ParameterWasBound(nameof(this.ObjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThrowOnDuplicate = this.ThrowOnDuplicate;
            
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
            var request = new Amazon.BackupStorage.Model.StartObjectRequest();
            
            if (cmdletContext.BackupJobId != null)
            {
                request.BackupJobId = cmdletContext.BackupJobId;
            }
            if (cmdletContext.ObjectName != null)
            {
                request.ObjectName = cmdletContext.ObjectName;
            }
            if (cmdletContext.ThrowOnDuplicate != null)
            {
                request.ThrowOnDuplicate = cmdletContext.ThrowOnDuplicate.Value;
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
        
        private Amazon.BackupStorage.Model.StartObjectResponse CallAWSServiceOperation(IAmazonBackupStorage client, Amazon.BackupStorage.Model.StartObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Storage", "StartObject");
            try
            {
                #if DESKTOP
                return client.StartObject(request);
                #elif CORECLR
                return client.StartObjectAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupJobId { get; set; }
            public System.String ObjectName { get; set; }
            public System.Boolean? ThrowOnDuplicate { get; set; }
            public System.Func<Amazon.BackupStorage.Model.StartObjectResponse, StartBAKSObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UploadId;
        }
        
    }
}
