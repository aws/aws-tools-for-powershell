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
using Amazon.TimestreamWrite;
using Amazon.TimestreamWrite.Model;

namespace Amazon.PowerShell.Cmdlets.TSW
{
    /// <summary>
    /// Modifies the retention duration of the memory store and magnetic store for your Timestream
    /// table. Note that the change in retention duration takes effect immediately. For example,
    /// if the retention period of the memory store was initially set to 2 hours and then
    /// changed to 24 hours, the memory store will be capable of holding 24 hours of data,
    /// but will be populated with 24 hours of data 22 hours after this change was made. Timestream
    /// does not retrieve data from the magnetic store to populate the memory store. 
    /// 
    ///  
    /// <para>
    /// Service quotas apply. For more information, see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html">Access
    /// Management</a> in the Timestream Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TSWTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamWrite.Model.Table")]
    [AWSCmdlet("Calls the Amazon Timestream Write UpdateTable API operation.", Operation = new[] {"UpdateTable"}, SelectReturnType = typeof(Amazon.TimestreamWrite.Model.UpdateTableResponse))]
    [AWSCmdletOutput("Amazon.TimestreamWrite.Model.Table or Amazon.TimestreamWrite.Model.UpdateTableResponse",
        "This cmdlet returns an Amazon.TimestreamWrite.Model.Table object.",
        "The service call response (type Amazon.TimestreamWrite.Model.UpdateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTSWTableCmdlet : AmazonTimestreamWriteClientCmdlet, IExecutor
    {
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream database.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter RetentionProperties_MagneticStoreRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The duration for which data must be stored in the magnetic store. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RetentionProperties_MagneticStoreRetentionPeriodInDays")]
        public System.Int64? RetentionProperties_MagneticStoreRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter RetentionProperties_MemoryStoreRetentionPeriodInHour
        /// <summary>
        /// <para>
        /// <para>The duration for which data must be stored in the memory store. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RetentionProperties_MemoryStoreRetentionPeriodInHours")]
        public System.Int64? RetentionProperties_MemoryStoreRetentionPeriodInHour { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Timesream table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Table'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamWrite.Model.UpdateTableResponse).
        /// Specifying the name of a property of type Amazon.TimestreamWrite.Model.UpdateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Table";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TSWTable (UpdateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamWrite.Model.UpdateTableResponse, UpdateTSWTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionProperties_MagneticStoreRetentionPeriodInDay = this.RetentionProperties_MagneticStoreRetentionPeriodInDay;
            #if MODULAR
            if (this.RetentionProperties_MagneticStoreRetentionPeriodInDay == null && ParameterWasBound(nameof(this.RetentionProperties_MagneticStoreRetentionPeriodInDay)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionProperties_MagneticStoreRetentionPeriodInDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionProperties_MemoryStoreRetentionPeriodInHour = this.RetentionProperties_MemoryStoreRetentionPeriodInHour;
            #if MODULAR
            if (this.RetentionProperties_MemoryStoreRetentionPeriodInHour == null && ParameterWasBound(nameof(this.RetentionProperties_MemoryStoreRetentionPeriodInHour)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionProperties_MemoryStoreRetentionPeriodInHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TimestreamWrite.Model.UpdateTableRequest();
            
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            
             // populate RetentionProperties
            var requestRetentionPropertiesIsNull = true;
            request.RetentionProperties = new Amazon.TimestreamWrite.Model.RetentionProperties();
            System.Int64? requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay = null;
            if (cmdletContext.RetentionProperties_MagneticStoreRetentionPeriodInDay != null)
            {
                requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay = cmdletContext.RetentionProperties_MagneticStoreRetentionPeriodInDay.Value;
            }
            if (requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay != null)
            {
                request.RetentionProperties.MagneticStoreRetentionPeriodInDays = requestRetentionProperties_retentionProperties_MagneticStoreRetentionPeriodInDay.Value;
                requestRetentionPropertiesIsNull = false;
            }
            System.Int64? requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour = null;
            if (cmdletContext.RetentionProperties_MemoryStoreRetentionPeriodInHour != null)
            {
                requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour = cmdletContext.RetentionProperties_MemoryStoreRetentionPeriodInHour.Value;
            }
            if (requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour != null)
            {
                request.RetentionProperties.MemoryStoreRetentionPeriodInHours = requestRetentionProperties_retentionProperties_MemoryStoreRetentionPeriodInHour.Value;
                requestRetentionPropertiesIsNull = false;
            }
             // determine if request.RetentionProperties should be set to null
            if (requestRetentionPropertiesIsNull)
            {
                request.RetentionProperties = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.TimestreamWrite.Model.UpdateTableResponse CallAWSServiceOperation(IAmazonTimestreamWrite client, Amazon.TimestreamWrite.Model.UpdateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Write", "UpdateTable");
            try
            {
                #if DESKTOP
                return client.UpdateTable(request);
                #elif CORECLR
                return client.UpdateTableAsync(request).GetAwaiter().GetResult();
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
            public System.String DatabaseName { get; set; }
            public System.Int64? RetentionProperties_MagneticStoreRetentionPeriodInDay { get; set; }
            public System.Int64? RetentionProperties_MemoryStoreRetentionPeriodInHour { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.TimestreamWrite.Model.UpdateTableResponse, UpdateTSWTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Table;
        }
        
    }
}
