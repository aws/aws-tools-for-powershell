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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Creates or updates the expiration configuration settings for records in a table, including
    /// the status of the configuration. If you enable record expiration for a table, records
    /// expire and are automatically removed from the table after the number of days that
    /// you specify.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:PutTableRecordExpirationConfiguration</c> permission
    /// to use this operation.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3TTableRecordExpirationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Tables PutTableRecordExpirationConfiguration API operation.", Operation = new[] {"PutTableRecordExpirationConfiguration"}, SelectReturnType = typeof(Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3TTableRecordExpirationConfigurationCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Settings_Day
        /// <summary>
        /// <para>
        /// <para>If you enable record expiration for a table, you can specify the number of days to
        /// retain your table records. For example, to retain your table records for one year,
        /// set this value to <c>365</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Value_Settings_Days")]
        public System.Int32? Settings_Day { get; set; }
        #endregion
        
        #region Parameter Value_Status
        /// <summary>
        /// <para>
        /// <para>The status of the expiration settings for records in the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Tables.TableRecordExpirationStatus")]
        public Amazon.S3Tables.TableRecordExpirationStatus Value_Status { get; set; }
        #endregion
        
        #region Parameter TableArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table.</para>
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
        public System.String TableArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3TTableRecordExpirationConfiguration (PutTableRecordExpirationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse, WriteS3TTableRecordExpirationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TableArn = this.TableArn;
            #if MODULAR
            if (this.TableArn == null && ParameterWasBound(nameof(this.TableArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TableArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Settings_Day = this.Settings_Day;
            context.Value_Status = this.Value_Status;
            
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
            var request = new Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationRequest();
            
            if (cmdletContext.TableArn != null)
            {
                request.TableArn = cmdletContext.TableArn;
            }
            
             // populate Value
            var requestValueIsNull = true;
            request.Value = new Amazon.S3Tables.Model.TableRecordExpirationConfigurationValue();
            Amazon.S3Tables.TableRecordExpirationStatus requestValue_value_Status = null;
            if (cmdletContext.Value_Status != null)
            {
                requestValue_value_Status = cmdletContext.Value_Status;
            }
            if (requestValue_value_Status != null)
            {
                request.Value.Status = requestValue_value_Status;
                requestValueIsNull = false;
            }
            Amazon.S3Tables.Model.TableRecordExpirationSettings requestValue_value_Settings = null;
            
             // populate Settings
            var requestValue_value_SettingsIsNull = true;
            requestValue_value_Settings = new Amazon.S3Tables.Model.TableRecordExpirationSettings();
            System.Int32? requestValue_value_Settings_settings_Day = null;
            if (cmdletContext.Settings_Day != null)
            {
                requestValue_value_Settings_settings_Day = cmdletContext.Settings_Day.Value;
            }
            if (requestValue_value_Settings_settings_Day != null)
            {
                requestValue_value_Settings.Days = requestValue_value_Settings_settings_Day.Value;
                requestValue_value_SettingsIsNull = false;
            }
             // determine if requestValue_value_Settings should be set to null
            if (requestValue_value_SettingsIsNull)
            {
                requestValue_value_Settings = null;
            }
            if (requestValue_value_Settings != null)
            {
                request.Value.Settings = requestValue_value_Settings;
                requestValueIsNull = false;
            }
             // determine if request.Value should be set to null
            if (requestValueIsNull)
            {
                request.Value = null;
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
        
        private Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "PutTableRecordExpirationConfiguration");
            try
            {
                #if DESKTOP
                return client.PutTableRecordExpirationConfiguration(request);
                #elif CORECLR
                return client.PutTableRecordExpirationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String TableArn { get; set; }
            public System.Int32? Settings_Day { get; set; }
            public Amazon.S3Tables.TableRecordExpirationStatus Value_Status { get; set; }
            public System.Func<Amazon.S3Tables.Model.PutTableRecordExpirationConfigurationResponse, WriteS3TTableRecordExpirationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
