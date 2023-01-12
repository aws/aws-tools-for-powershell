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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new configured table resource.
    /// </summary>
    [Cmdlet("New", "CRSConfiguredTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.ConfiguredTable")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateConfiguredTable API operation.", Operation = new[] {"CreateConfiguredTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateConfiguredTableResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.ConfiguredTable or Amazon.CleanRooms.Model.CreateConfiguredTableResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.ConfiguredTable object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateConfiguredTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCRSConfiguredTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        #region Parameter AllowedColumn
        /// <summary>
        /// <para>
        /// <para>The columns of the underlying table that can be used by collaborations or analysis
        /// rules.</para>
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
        [Alias("AllowedColumns")]
        public System.String[] AllowedColumn { get; set; }
        #endregion
        
        #region Parameter AnalysisMethod
        /// <summary>
        /// <para>
        /// <para>The analysis method for the configured tables. The only valid value is currently `DIRECT_QUERY`.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.AnalysisMethod")]
        public Amazon.CleanRooms.AnalysisMethod AnalysisMethod { get; set; }
        #endregion
        
        #region Parameter Glue_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database the AWS Glue table belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Glue_DatabaseName")]
        public System.String Glue_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the configured table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the configured table.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Glue_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS Glue table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableReference_Glue_TableName")]
        public System.String Glue_TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfiguredTable'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateConfiguredTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateConfiguredTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfiguredTable";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSConfiguredTable (CreateConfiguredTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateConfiguredTableResponse, NewCRSConfiguredTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedColumn != null)
            {
                context.AllowedColumn = new List<System.String>(this.AllowedColumn);
            }
            #if MODULAR
            if (this.AllowedColumn == null && ParameterWasBound(nameof(this.AllowedColumn)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowedColumn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnalysisMethod = this.AnalysisMethod;
            #if MODULAR
            if (this.AnalysisMethod == null && ParameterWasBound(nameof(this.AnalysisMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalysisMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Glue_DatabaseName = this.Glue_DatabaseName;
            context.Glue_TableName = this.Glue_TableName;
            
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
            var request = new Amazon.CleanRooms.Model.CreateConfiguredTableRequest();
            
            if (cmdletContext.AllowedColumn != null)
            {
                request.AllowedColumns = cmdletContext.AllowedColumn;
            }
            if (cmdletContext.AnalysisMethod != null)
            {
                request.AnalysisMethod = cmdletContext.AnalysisMethod;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate TableReference
            var requestTableReferenceIsNull = true;
            request.TableReference = new Amazon.CleanRooms.Model.TableReference();
            Amazon.CleanRooms.Model.GlueTableReference requestTableReference_tableReference_Glue = null;
            
             // populate Glue
            var requestTableReference_tableReference_GlueIsNull = true;
            requestTableReference_tableReference_Glue = new Amazon.CleanRooms.Model.GlueTableReference();
            System.String requestTableReference_tableReference_Glue_glue_DatabaseName = null;
            if (cmdletContext.Glue_DatabaseName != null)
            {
                requestTableReference_tableReference_Glue_glue_DatabaseName = cmdletContext.Glue_DatabaseName;
            }
            if (requestTableReference_tableReference_Glue_glue_DatabaseName != null)
            {
                requestTableReference_tableReference_Glue.DatabaseName = requestTableReference_tableReference_Glue_glue_DatabaseName;
                requestTableReference_tableReference_GlueIsNull = false;
            }
            System.String requestTableReference_tableReference_Glue_glue_TableName = null;
            if (cmdletContext.Glue_TableName != null)
            {
                requestTableReference_tableReference_Glue_glue_TableName = cmdletContext.Glue_TableName;
            }
            if (requestTableReference_tableReference_Glue_glue_TableName != null)
            {
                requestTableReference_tableReference_Glue.TableName = requestTableReference_tableReference_Glue_glue_TableName;
                requestTableReference_tableReference_GlueIsNull = false;
            }
             // determine if requestTableReference_tableReference_Glue should be set to null
            if (requestTableReference_tableReference_GlueIsNull)
            {
                requestTableReference_tableReference_Glue = null;
            }
            if (requestTableReference_tableReference_Glue != null)
            {
                request.TableReference.Glue = requestTableReference_tableReference_Glue;
                requestTableReferenceIsNull = false;
            }
             // determine if request.TableReference should be set to null
            if (requestTableReferenceIsNull)
            {
                request.TableReference = null;
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
        
        private Amazon.CleanRooms.Model.CreateConfiguredTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateConfiguredTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateConfiguredTable");
            try
            {
                #if DESKTOP
                return client.CreateConfiguredTable(request);
                #elif CORECLR
                return client.CreateConfiguredTableAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedColumn { get; set; }
            public Amazon.CleanRooms.AnalysisMethod AnalysisMethod { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Glue_DatabaseName { get; set; }
            public System.String Glue_TableName { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateConfiguredTableResponse, NewCRSConfiguredTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfiguredTable;
        }
        
    }
}
