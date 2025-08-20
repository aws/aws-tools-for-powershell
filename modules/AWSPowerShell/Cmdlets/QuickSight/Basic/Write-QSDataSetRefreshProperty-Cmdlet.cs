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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates or updates the dataset refresh properties for the dataset.
    /// </summary>
    [Cmdlet("Write", "QSDataSetRefreshProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight PutDataSetRefreshProperties API operation.", Operation = new[] {"PutDataSetRefreshProperties"}, SelectReturnType = typeof(Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse object containing multiple properties."
    )]
    public partial class WriteQSDataSetRefreshPropertyCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmailAlert_AlertStatus
        /// <summary>
        /// <para>
        /// <para>The status value that determines if email alerts are sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSetRefreshProperties_FailureConfiguration_EmailAlert_AlertStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.RefreshFailureAlertStatus")]
        public Amazon.QuickSight.RefreshFailureAlertStatus EmailAlert_AlertStatus { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter LookbackWindow_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the lookback window column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_ColumnName")]
        public System.String LookbackWindow_ColumnName { get; set; }
        #endregion
        
        #region Parameter DataSetId
        /// <summary>
        /// <para>
        /// <para>The ID of the dataset.</para>
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
        public System.String DataSetId { get; set; }
        #endregion
        
        #region Parameter LookbackWindow_Size
        /// <summary>
        /// <para>
        /// <para>The lookback window column size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_Size")]
        public System.Int64? LookbackWindow_Size { get; set; }
        #endregion
        
        #region Parameter LookbackWindow_SizeUnit
        /// <summary>
        /// <para>
        /// <para>The size unit that is used for the lookback window column. Valid values for this structure
        /// are <c>HOUR</c>, <c>DAY</c>, and <c>WEEK</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_SizeUnit")]
        [AWSConstantClassSource("Amazon.QuickSight.LookbackWindowSizeUnit")]
        public Amazon.QuickSight.LookbackWindowSizeUnit LookbackWindow_SizeUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataSetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataSetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataSetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-QSDataSetRefreshProperty (PutDataSetRefreshProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse, WriteQSDataSetRefreshPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataSetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSetId = this.DataSetId;
            #if MODULAR
            if (this.DataSetId == null && ParameterWasBound(nameof(this.DataSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailAlert_AlertStatus = this.EmailAlert_AlertStatus;
            context.LookbackWindow_ColumnName = this.LookbackWindow_ColumnName;
            context.LookbackWindow_Size = this.LookbackWindow_Size;
            context.LookbackWindow_SizeUnit = this.LookbackWindow_SizeUnit;
            
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
            var request = new Amazon.QuickSight.Model.PutDataSetRefreshPropertiesRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DataSetId != null)
            {
                request.DataSetId = cmdletContext.DataSetId;
            }
            
             // populate DataSetRefreshProperties
            request.DataSetRefreshProperties = new Amazon.QuickSight.Model.DataSetRefreshProperties();
            Amazon.QuickSight.Model.RefreshFailureConfiguration requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration = null;
            
             // populate FailureConfiguration
            var requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfigurationIsNull = true;
            requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration = new Amazon.QuickSight.Model.RefreshFailureConfiguration();
            Amazon.QuickSight.Model.RefreshFailureEmailAlert requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert = null;
            
             // populate EmailAlert
            var requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlertIsNull = true;
            requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert = new Amazon.QuickSight.Model.RefreshFailureEmailAlert();
            Amazon.QuickSight.RefreshFailureAlertStatus requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert_emailAlert_AlertStatus = null;
            if (cmdletContext.EmailAlert_AlertStatus != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert_emailAlert_AlertStatus = cmdletContext.EmailAlert_AlertStatus;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert_emailAlert_AlertStatus != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert.AlertStatus = requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert_emailAlert_AlertStatus;
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlertIsNull = false;
            }
             // determine if requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert should be set to null
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlertIsNull)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert = null;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration.EmailAlert = requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration_dataSetRefreshProperties_FailureConfiguration_EmailAlert;
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfigurationIsNull = false;
            }
             // determine if requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration should be set to null
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfigurationIsNull)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration = null;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration != null)
            {
                request.DataSetRefreshProperties.FailureConfiguration = requestDataSetRefreshProperties_dataSetRefreshProperties_FailureConfiguration;
            }
            Amazon.QuickSight.Model.RefreshConfiguration requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration = null;
            
             // populate RefreshConfiguration
            var requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfigurationIsNull = true;
            requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration = new Amazon.QuickSight.Model.RefreshConfiguration();
            Amazon.QuickSight.Model.IncrementalRefresh requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh = null;
            
             // populate IncrementalRefresh
            var requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefreshIsNull = true;
            requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh = new Amazon.QuickSight.Model.IncrementalRefresh();
            Amazon.QuickSight.Model.LookbackWindow requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow = null;
            
             // populate LookbackWindow
            var requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindowIsNull = true;
            requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow = new Amazon.QuickSight.Model.LookbackWindow();
            System.String requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_ColumnName = null;
            if (cmdletContext.LookbackWindow_ColumnName != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_ColumnName = cmdletContext.LookbackWindow_ColumnName;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_ColumnName != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow.ColumnName = requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_ColumnName;
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindowIsNull = false;
            }
            System.Int64? requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_Size = null;
            if (cmdletContext.LookbackWindow_Size != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_Size = cmdletContext.LookbackWindow_Size.Value;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_Size != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow.Size = requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_Size.Value;
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindowIsNull = false;
            }
            Amazon.QuickSight.LookbackWindowSizeUnit requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_SizeUnit = null;
            if (cmdletContext.LookbackWindow_SizeUnit != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_SizeUnit = cmdletContext.LookbackWindow_SizeUnit;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_SizeUnit != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow.SizeUnit = requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_lookbackWindow_SizeUnit;
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindowIsNull = false;
            }
             // determine if requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow should be set to null
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindowIsNull)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow = null;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh.LookbackWindow = requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow;
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefreshIsNull = false;
            }
             // determine if requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh should be set to null
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefreshIsNull)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh = null;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh != null)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration.IncrementalRefresh = requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration_dataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh;
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfigurationIsNull = false;
            }
             // determine if requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration should be set to null
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfigurationIsNull)
            {
                requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration = null;
            }
            if (requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration != null)
            {
                request.DataSetRefreshProperties.RefreshConfiguration = requestDataSetRefreshProperties_dataSetRefreshProperties_RefreshConfiguration;
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
        
        private Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.PutDataSetRefreshPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "PutDataSetRefreshProperties");
            try
            {
                #if DESKTOP
                return client.PutDataSetRefreshProperties(request);
                #elif CORECLR
                return client.PutDataSetRefreshPropertiesAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DataSetId { get; set; }
            public Amazon.QuickSight.RefreshFailureAlertStatus EmailAlert_AlertStatus { get; set; }
            public System.String LookbackWindow_ColumnName { get; set; }
            public System.Int64? LookbackWindow_Size { get; set; }
            public Amazon.QuickSight.LookbackWindowSizeUnit LookbackWindow_SizeUnit { get; set; }
            public System.Func<Amazon.QuickSight.Model.PutDataSetRefreshPropertiesResponse, WriteQSDataSetRefreshPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
