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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates a new custom tape pool. You can use custom tape pool to enable tape retention
    /// lock on tapes that are archived in the custom pool.
    /// </summary>
    [Cmdlet("New", "SGTapePool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateTapePool API operation.", Operation = new[] {"CreateTapePool"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.CreateTapePoolResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.CreateTapePoolResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.CreateTapePoolResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGTapePoolCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter PoolName
        /// <summary>
        /// <para>
        /// <para>The name of the new custom tape pool.</para>
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
        public System.String PoolName { get; set; }
        #endregion
        
        #region Parameter RetentionLockTimeInDay
        /// <summary>
        /// <para>
        /// <para>Tape retention lock time is set in days. Tape retention lock can be enabled for up
        /// to 100 years (36,500 days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionLockTimeInDays")]
        public System.Int32? RetentionLockTimeInDay { get; set; }
        #endregion
        
        #region Parameter RetentionLockType
        /// <summary>
        /// <para>
        /// <para>Tape retention lock can be configured in two modes. When configured in governance
        /// mode, Amazon Web Services accounts with specific IAM permissions are authorized to
        /// remove the tape retention lock from archived virtual tapes. When configured in compliance
        /// mode, the tape retention lock cannot be removed by any user, including the root Amazon
        /// Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.RetentionLockType")]
        public Amazon.StorageGateway.RetentionLockType RetentionLockType { get; set; }
        #endregion
        
        #region Parameter StorageClass
        /// <summary>
        /// <para>
        /// <para>The storage class that is associated with the new custom pool. When you use your backup
        /// application to eject the tape, the tape is archived directly into the storage class
        /// (S3 Glacier or S3 Glacier Deep Archive) that corresponds to the pool.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.StorageGateway.TapeStorageClass")]
        public Amazon.StorageGateway.TapeStorageClass StorageClass { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that can be assigned to tape pool. Each tag is a key-value
        /// pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PoolARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.CreateTapePoolResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.CreateTapePoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PoolARN";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGTapePool (CreateTapePool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.CreateTapePoolResponse, NewSGTapePoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PoolName = this.PoolName;
            #if MODULAR
            if (this.PoolName == null && ParameterWasBound(nameof(this.PoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionLockTimeInDay = this.RetentionLockTimeInDay;
            context.RetentionLockType = this.RetentionLockType;
            context.StorageClass = this.StorageClass;
            #if MODULAR
            if (this.StorageClass == null && ParameterWasBound(nameof(this.StorageClass)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
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
            var request = new Amazon.StorageGateway.Model.CreateTapePoolRequest();
            
            if (cmdletContext.PoolName != null)
            {
                request.PoolName = cmdletContext.PoolName;
            }
            if (cmdletContext.RetentionLockTimeInDay != null)
            {
                request.RetentionLockTimeInDays = cmdletContext.RetentionLockTimeInDay.Value;
            }
            if (cmdletContext.RetentionLockType != null)
            {
                request.RetentionLockType = cmdletContext.RetentionLockType;
            }
            if (cmdletContext.StorageClass != null)
            {
                request.StorageClass = cmdletContext.StorageClass;
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
        
        private Amazon.StorageGateway.Model.CreateTapePoolResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateTapePoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateTapePool");
            try
            {
                #if DESKTOP
                return client.CreateTapePool(request);
                #elif CORECLR
                return client.CreateTapePoolAsync(request).GetAwaiter().GetResult();
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
            public System.String PoolName { get; set; }
            public System.Int32? RetentionLockTimeInDay { get; set; }
            public Amazon.StorageGateway.RetentionLockType RetentionLockType { get; set; }
            public Amazon.StorageGateway.TapeStorageClass StorageClass { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.StorageGateway.Model.CreateTapePoolResponse, NewSGTapePoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PoolARN;
        }
        
    }
}
