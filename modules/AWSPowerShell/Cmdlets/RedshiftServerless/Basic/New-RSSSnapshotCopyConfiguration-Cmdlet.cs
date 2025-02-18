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
using System.Threading;
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Creates a snapshot copy configuration that lets you copy snapshots to another Amazon
    /// Web Services Region.
    /// </summary>
    [Cmdlet("New", "RSSSnapshotCopyConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.SnapshotCopyConfiguration")]
    [AWSCmdlet("Calls the Redshift Serverless CreateSnapshotCopyConfiguration API operation.", Operation = new[] {"CreateSnapshotCopyConfiguration"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.SnapshotCopyConfiguration or Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.SnapshotCopyConfiguration object.",
        "The service call response (type Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRSSSnapshotCopyConfigurationCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key to use to encrypt your snapshots in the destination Amazon Web Services
        /// Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationKmsKeyId { get; set; }
        #endregion
        
        #region Parameter DestinationRegion
        /// <summary>
        /// <para>
        /// <para>The destination Amazon Web Services Region that you want to copy snapshots to.</para>
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
        public System.String DestinationRegion { get; set; }
        #endregion
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the namespace to copy snapshots from.</para>
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
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The retention period of the snapshots that you copy to the destination Amazon Web
        /// Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapshotCopyConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapshotCopyConfiguration";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NamespaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSSSnapshotCopyConfiguration (CreateSnapshotCopyConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse, NewRSSSnapshotCopyConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationKmsKeyId = this.DestinationKmsKeyId;
            context.DestinationRegion = this.DestinationRegion;
            #if MODULAR
            if (this.DestinationRegion == null && ParameterWasBound(nameof(this.DestinationRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NamespaceName = this.NamespaceName;
            #if MODULAR
            if (this.NamespaceName == null && ParameterWasBound(nameof(this.NamespaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NamespaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotRetentionPeriod = this.SnapshotRetentionPeriod;
            
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
            var request = new Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationRequest();
            
            if (cmdletContext.DestinationKmsKeyId != null)
            {
                request.DestinationKmsKeyId = cmdletContext.DestinationKmsKeyId;
            }
            if (cmdletContext.DestinationRegion != null)
            {
                request.DestinationRegion = cmdletContext.DestinationRegion;
            }
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
            }
            if (cmdletContext.SnapshotRetentionPeriod != null)
            {
                request.SnapshotRetentionPeriod = cmdletContext.SnapshotRetentionPeriod.Value;
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
        
        private Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "CreateSnapshotCopyConfiguration");
            try
            {
                return client.CreateSnapshotCopyConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationKmsKeyId { get; set; }
            public System.String DestinationRegion { get; set; }
            public System.String NamespaceName { get; set; }
            public System.Int32? SnapshotRetentionPeriod { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.CreateSnapshotCopyConfigurationResponse, NewRSSSnapshotCopyConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapshotCopyConfiguration;
        }
        
    }
}
