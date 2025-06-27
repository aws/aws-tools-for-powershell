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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Updates a metadata table in the Data Catalog.
    /// </summary>
    [Cmdlet("Update", "GLUETable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue UpdateTable API operation.", Operation = new[] {"UpdateTable"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateTableResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.UpdateTableResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.UpdateTableResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateGLUETableCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog where the table resides. If none is provided, the Amazon
        /// Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the catalog database in which the table resides. For Hive compatibility,
        /// this name is entirely lowercase.</para>
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
        
        #region Parameter ForceUpdate
        /// <summary>
        /// <para>
        /// <para>A flag that can be set to true to ignore matching storage descriptor and subobject
        /// matching requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceUpdate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the table within the specified database that will be created
        /// in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SkipArchive
        /// <summary>
        /// <para>
        /// <para>By default, <c>UpdateTable</c> always creates an archived version of the table before
        /// updating it. However, if <c>skipArchive</c> is set to true, <c>UpdateTable</c> does
        /// not create the archived version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipArchive { get; set; }
        #endregion
        
        #region Parameter TableInput
        /// <summary>
        /// <para>
        /// <para>An updated <c>TableInput</c> object to define the metadata table in the catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public Amazon.Glue.Model.TableInput TableInput { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The transaction ID at which to update the table contents. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter UpdateIcebergTableInput_Update
        /// <summary>
        /// <para>
        /// <para>The list of table update operations that specify the changes to be made to the Iceberg
        /// table, including schema modifications, partition specifications, and table properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput_Updates")]
        public Amazon.Glue.Model.IcebergTableUpdate[] UpdateIcebergTableInput_Update { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID at which to update the table contents. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter ViewUpdateAction
        /// <summary>
        /// <para>
        /// <para>The operation to be performed when updating the view.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ViewUpdateAction")]
        public Amazon.Glue.ViewUpdateAction ViewUpdateAction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateTableResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableInput parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableInput' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableInput' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUETable (UpdateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateTableResponse, UpdateGLUETableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableInput;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceUpdate = this.ForceUpdate;
            context.Name = this.Name;
            context.SkipArchive = this.SkipArchive;
            context.TableInput = this.TableInput;
            context.TransactionId = this.TransactionId;
            if (this.UpdateIcebergTableInput_Update != null)
            {
                context.UpdateIcebergTableInput_Update = new List<Amazon.Glue.Model.IcebergTableUpdate>(this.UpdateIcebergTableInput_Update);
            }
            context.VersionId = this.VersionId;
            context.ViewUpdateAction = this.ViewUpdateAction;
            
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
            var request = new Amazon.Glue.Model.UpdateTableRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.ForceUpdate != null)
            {
                request.Force = cmdletContext.ForceUpdate.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SkipArchive != null)
            {
                request.SkipArchive = cmdletContext.SkipArchive.Value;
            }
            if (cmdletContext.TableInput != null)
            {
                request.TableInput = cmdletContext.TableInput;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
            }
            
             // populate UpdateOpenTableFormatInput
            var requestUpdateOpenTableFormatInputIsNull = true;
            request.UpdateOpenTableFormatInput = new Amazon.Glue.Model.UpdateOpenTableFormatInput();
            Amazon.Glue.Model.UpdateIcebergInput requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput = null;
            
             // populate UpdateIcebergInput
            var requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInputIsNull = true;
            requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput = new Amazon.Glue.Model.UpdateIcebergInput();
            Amazon.Glue.Model.UpdateIcebergTableInput requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput = null;
            
             // populate UpdateIcebergTableInput
            var requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInputIsNull = true;
            requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput = new Amazon.Glue.Model.UpdateIcebergTableInput();
            List<Amazon.Glue.Model.IcebergTableUpdate> requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput_updateIcebergTableInput_Update = null;
            if (cmdletContext.UpdateIcebergTableInput_Update != null)
            {
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput_updateIcebergTableInput_Update = cmdletContext.UpdateIcebergTableInput_Update;
            }
            if (requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput_updateIcebergTableInput_Update != null)
            {
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput.Updates = requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput_updateIcebergTableInput_Update;
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInputIsNull = false;
            }
             // determine if requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput should be set to null
            if (requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInputIsNull)
            {
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput = null;
            }
            if (requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput != null)
            {
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput.UpdateIcebergTableInput = requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput_updateOpenTableFormatInput_UpdateIcebergInput_UpdateIcebergTableInput;
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInputIsNull = false;
            }
             // determine if requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput should be set to null
            if (requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInputIsNull)
            {
                requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput = null;
            }
            if (requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput != null)
            {
                request.UpdateOpenTableFormatInput.UpdateIcebergInput = requestUpdateOpenTableFormatInput_updateOpenTableFormatInput_UpdateIcebergInput;
                requestUpdateOpenTableFormatInputIsNull = false;
            }
             // determine if request.UpdateOpenTableFormatInput should be set to null
            if (requestUpdateOpenTableFormatInputIsNull)
            {
                request.UpdateOpenTableFormatInput = null;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.ViewUpdateAction != null)
            {
                request.ViewUpdateAction = cmdletContext.ViewUpdateAction;
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
        
        private Amazon.Glue.Model.UpdateTableResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateTable");
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
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public System.Boolean? ForceUpdate { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? SkipArchive { get; set; }
            public Amazon.Glue.Model.TableInput TableInput { get; set; }
            public System.String TransactionId { get; set; }
            public List<Amazon.Glue.Model.IcebergTableUpdate> UpdateIcebergTableInput_Update { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.Glue.ViewUpdateAction ViewUpdateAction { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateTableResponse, UpdateGLUETableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
