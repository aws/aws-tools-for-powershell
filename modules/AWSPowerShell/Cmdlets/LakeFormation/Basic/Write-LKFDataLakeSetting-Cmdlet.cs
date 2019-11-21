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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// The AWS Lake Formation principal.
    /// </summary>
    [Cmdlet("Write", "LKFDataLakeSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lake Formation PutDataLakeSettings API operation.", Operation = new[] {"PutDataLakeSettings"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.PutDataLakeSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.LakeFormation.Model.PutDataLakeSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LakeFormation.Model.PutDataLakeSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLKFDataLakeSettingCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, the account ID. The Data Catalog
        /// is the persistent metadata store. It contains database definitions, table definitions,
        /// and other control information to manage your AWS Lake Formation environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_CreateDatabaseDefaultPermission
        /// <summary>
        /// <para>
        /// <para>A list of up to three principal permissions entries for default create database permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_CreateDatabaseDefaultPermissions")]
        public Amazon.LakeFormation.Model.PrincipalPermissions[] DataLakeSettings_CreateDatabaseDefaultPermission { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_CreateTableDefaultPermission
        /// <summary>
        /// <para>
        /// <para>A list of up to three principal permissions entries for default create table permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_CreateTableDefaultPermissions")]
        public Amazon.LakeFormation.Model.PrincipalPermissions[] DataLakeSettings_CreateTableDefaultPermission { get; set; }
        #endregion
        
        #region Parameter DataLakeSettings_DataLakeAdmin
        /// <summary>
        /// <para>
        /// <para>A list of AWS Lake Formation principals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLakeSettings_DataLakeAdmins")]
        public Amazon.LakeFormation.Model.DataLakePrincipal[] DataLakeSettings_DataLakeAdmin { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.PutDataLakeSettingsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CatalogId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CatalogId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LKFDataLakeSetting (PutDataLakeSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.PutDataLakeSettingsResponse, WriteLKFDataLakeSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CatalogId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            if (this.DataLakeSettings_CreateDatabaseDefaultPermission != null)
            {
                context.DataLakeSettings_CreateDatabaseDefaultPermission = new List<Amazon.LakeFormation.Model.PrincipalPermissions>(this.DataLakeSettings_CreateDatabaseDefaultPermission);
            }
            if (this.DataLakeSettings_CreateTableDefaultPermission != null)
            {
                context.DataLakeSettings_CreateTableDefaultPermission = new List<Amazon.LakeFormation.Model.PrincipalPermissions>(this.DataLakeSettings_CreateTableDefaultPermission);
            }
            if (this.DataLakeSettings_DataLakeAdmin != null)
            {
                context.DataLakeSettings_DataLakeAdmin = new List<Amazon.LakeFormation.Model.DataLakePrincipal>(this.DataLakeSettings_DataLakeAdmin);
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
            var request = new Amazon.LakeFormation.Model.PutDataLakeSettingsRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            
             // populate DataLakeSettings
            var requestDataLakeSettingsIsNull = true;
            request.DataLakeSettings = new Amazon.LakeFormation.Model.DataLakeSettings();
            List<Amazon.LakeFormation.Model.PrincipalPermissions> requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission = null;
            if (cmdletContext.DataLakeSettings_CreateDatabaseDefaultPermission != null)
            {
                requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission = cmdletContext.DataLakeSettings_CreateDatabaseDefaultPermission;
            }
            if (requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission != null)
            {
                request.DataLakeSettings.CreateDatabaseDefaultPermissions = requestDataLakeSettings_dataLakeSettings_CreateDatabaseDefaultPermission;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.PrincipalPermissions> requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission = null;
            if (cmdletContext.DataLakeSettings_CreateTableDefaultPermission != null)
            {
                requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission = cmdletContext.DataLakeSettings_CreateTableDefaultPermission;
            }
            if (requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission != null)
            {
                request.DataLakeSettings.CreateTableDefaultPermissions = requestDataLakeSettings_dataLakeSettings_CreateTableDefaultPermission;
                requestDataLakeSettingsIsNull = false;
            }
            List<Amazon.LakeFormation.Model.DataLakePrincipal> requestDataLakeSettings_dataLakeSettings_DataLakeAdmin = null;
            if (cmdletContext.DataLakeSettings_DataLakeAdmin != null)
            {
                requestDataLakeSettings_dataLakeSettings_DataLakeAdmin = cmdletContext.DataLakeSettings_DataLakeAdmin;
            }
            if (requestDataLakeSettings_dataLakeSettings_DataLakeAdmin != null)
            {
                request.DataLakeSettings.DataLakeAdmins = requestDataLakeSettings_dataLakeSettings_DataLakeAdmin;
                requestDataLakeSettingsIsNull = false;
            }
             // determine if request.DataLakeSettings should be set to null
            if (requestDataLakeSettingsIsNull)
            {
                request.DataLakeSettings = null;
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
        
        private Amazon.LakeFormation.Model.PutDataLakeSettingsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.PutDataLakeSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "PutDataLakeSettings");
            try
            {
                #if DESKTOP
                return client.PutDataLakeSettings(request);
                #elif CORECLR
                return client.PutDataLakeSettingsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.LakeFormation.Model.PrincipalPermissions> DataLakeSettings_CreateDatabaseDefaultPermission { get; set; }
            public List<Amazon.LakeFormation.Model.PrincipalPermissions> DataLakeSettings_CreateTableDefaultPermission { get; set; }
            public List<Amazon.LakeFormation.Model.DataLakePrincipal> DataLakeSettings_DataLakeAdmin { get; set; }
            public System.Func<Amazon.LakeFormation.Model.PutDataLakeSettingsResponse, WriteLKFDataLakeSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
