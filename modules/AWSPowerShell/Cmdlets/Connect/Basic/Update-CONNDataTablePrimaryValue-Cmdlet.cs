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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the primary values for a record. This operation affects all existing values
    /// that are currently associated to the record and its primary values. Users that have
    /// restrictions on attributes and/or primary values are not authorized to use this endpoint.
    /// The combination of new primary values must be unique within the table.
    /// </summary>
    [Cmdlet("Update", "CONNDataTablePrimaryValue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.DataTableLockVersion")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateDataTablePrimaryValues API operation.", Operation = new[] {"UpdateDataTablePrimaryValues"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.DataTableLockVersion or Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse",
        "This cmdlet returns an Amazon.Connect.Model.DataTableLockVersion object.",
        "The service call response (type Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNDataTablePrimaryValueCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LockVersion_Attribute
        /// <summary>
        /// <para>
        /// <para>The lock version for a specific attribute. When the ValueLockLevel is ATTRIBUTE, this
        /// version changes when any value for the attribute changes. For other lock levels, it
        /// only changes when the attribute's properties are directly updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LockVersion_Attribute { get; set; }
        #endregion
        
        #region Parameter LockVersion_DataTable
        /// <summary>
        /// <para>
        /// <para>The lock version for the data table itself. Used for optimistic locking and table
        /// versioning. Changes with each update to the table's metadata or structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LockVersion_DataTable { get; set; }
        #endregion
        
        #region Parameter DataTableId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data table. Must also accept the table ARN with or without
        /// a version alias. If the version is provided as part of the identifier or ARN, the
        /// version must be one of the two available system managed aliases, $SAVED or $LATEST.</para>
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
        public System.String DataTableId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Amazon Connect instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter NewPrimaryValue
        /// <summary>
        /// <para>
        /// <para>The new primary values for the record. Required and must include values for all primary
        /// attributes. The combination must be unique within the table.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NewPrimaryValues")]
        public Amazon.Connect.Model.PrimaryValue[] NewPrimaryValue { get; set; }
        #endregion
        
        #region Parameter LockVersion_PrimaryValue
        /// <summary>
        /// <para>
        /// <para>The lock version for a specific set of primary values (record). This includes the
        /// default record even if the table does not have any primary attributes. Used for record-level
        /// locking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LockVersion_PrimaryValues")]
        public System.String LockVersion_PrimaryValue { get; set; }
        #endregion
        
        #region Parameter PrimaryValue
        /// <summary>
        /// <para>
        /// <para>The current primary values for the record. Required and must include values for all
        /// primary attributes. Fails if the table has primary attributes and some primary values
        /// are omitted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PrimaryValues")]
        public Amazon.Connect.Model.PrimaryValue[] PrimaryValue { get; set; }
        #endregion
        
        #region Parameter LockVersion_Value
        /// <summary>
        /// <para>
        /// <para>The lock version for a specific value. Changes each time the individual value is modified.
        /// Used for the finest-grained locking control.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LockVersion_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LockVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LockVersion";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DataTableId),
                nameof(this.InstanceId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNDataTablePrimaryValue (UpdateDataTablePrimaryValues)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse, UpdateCONNDataTablePrimaryValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataTableId = this.DataTableId;
            #if MODULAR
            if (this.DataTableId == null && ParameterWasBound(nameof(this.DataTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LockVersion_Attribute = this.LockVersion_Attribute;
            context.LockVersion_DataTable = this.LockVersion_DataTable;
            context.LockVersion_PrimaryValue = this.LockVersion_PrimaryValue;
            context.LockVersion_Value = this.LockVersion_Value;
            if (this.NewPrimaryValue != null)
            {
                context.NewPrimaryValue = new List<Amazon.Connect.Model.PrimaryValue>(this.NewPrimaryValue);
            }
            #if MODULAR
            if (this.NewPrimaryValue == null && ParameterWasBound(nameof(this.NewPrimaryValue)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrimaryValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PrimaryValue != null)
            {
                context.PrimaryValue = new List<Amazon.Connect.Model.PrimaryValue>(this.PrimaryValue);
            }
            #if MODULAR
            if (this.PrimaryValue == null && ParameterWasBound(nameof(this.PrimaryValue)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateDataTablePrimaryValuesRequest();
            
            if (cmdletContext.DataTableId != null)
            {
                request.DataTableId = cmdletContext.DataTableId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate LockVersion
            var requestLockVersionIsNull = true;
            request.LockVersion = new Amazon.Connect.Model.DataTableLockVersion();
            System.String requestLockVersion_lockVersion_Attribute = null;
            if (cmdletContext.LockVersion_Attribute != null)
            {
                requestLockVersion_lockVersion_Attribute = cmdletContext.LockVersion_Attribute;
            }
            if (requestLockVersion_lockVersion_Attribute != null)
            {
                request.LockVersion.Attribute = requestLockVersion_lockVersion_Attribute;
                requestLockVersionIsNull = false;
            }
            System.String requestLockVersion_lockVersion_DataTable = null;
            if (cmdletContext.LockVersion_DataTable != null)
            {
                requestLockVersion_lockVersion_DataTable = cmdletContext.LockVersion_DataTable;
            }
            if (requestLockVersion_lockVersion_DataTable != null)
            {
                request.LockVersion.DataTable = requestLockVersion_lockVersion_DataTable;
                requestLockVersionIsNull = false;
            }
            System.String requestLockVersion_lockVersion_PrimaryValue = null;
            if (cmdletContext.LockVersion_PrimaryValue != null)
            {
                requestLockVersion_lockVersion_PrimaryValue = cmdletContext.LockVersion_PrimaryValue;
            }
            if (requestLockVersion_lockVersion_PrimaryValue != null)
            {
                request.LockVersion.PrimaryValues = requestLockVersion_lockVersion_PrimaryValue;
                requestLockVersionIsNull = false;
            }
            System.String requestLockVersion_lockVersion_Value = null;
            if (cmdletContext.LockVersion_Value != null)
            {
                requestLockVersion_lockVersion_Value = cmdletContext.LockVersion_Value;
            }
            if (requestLockVersion_lockVersion_Value != null)
            {
                request.LockVersion.Value = requestLockVersion_lockVersion_Value;
                requestLockVersionIsNull = false;
            }
             // determine if request.LockVersion should be set to null
            if (requestLockVersionIsNull)
            {
                request.LockVersion = null;
            }
            if (cmdletContext.NewPrimaryValue != null)
            {
                request.NewPrimaryValues = cmdletContext.NewPrimaryValue;
            }
            if (cmdletContext.PrimaryValue != null)
            {
                request.PrimaryValues = cmdletContext.PrimaryValue;
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
        
        private Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateDataTablePrimaryValuesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateDataTablePrimaryValues");
            try
            {
                #if DESKTOP
                return client.UpdateDataTablePrimaryValues(request);
                #elif CORECLR
                return client.UpdateDataTablePrimaryValuesAsync(request).GetAwaiter().GetResult();
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
            public System.String DataTableId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String LockVersion_Attribute { get; set; }
            public System.String LockVersion_DataTable { get; set; }
            public System.String LockVersion_PrimaryValue { get; set; }
            public System.String LockVersion_Value { get; set; }
            public List<Amazon.Connect.Model.PrimaryValue> NewPrimaryValue { get; set; }
            public List<Amazon.Connect.Model.PrimaryValue> PrimaryValue { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateDataTablePrimaryValuesResponse, UpdateCONNDataTablePrimaryValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LockVersion;
        }
        
    }
}
