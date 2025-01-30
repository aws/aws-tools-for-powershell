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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Sends a list of asset property values to IoT SiteWise. Each value is a timestamp-quality-value
    /// (TQV) data point. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/ingest-api.html">Ingesting
    /// data using the API</a> in the <i>IoT SiteWise User Guide</i>.
    /// 
    ///  
    /// <para>
    /// To identify an asset property, you must specify one of the following:
    /// </para><ul><li><para>
    /// The <c>assetId</c> and <c>propertyId</c> of an asset property.
    /// </para></li><li><para>
    /// A <c>propertyAlias</c>, which is a data stream alias (for example, <c>/company/windfarm/3/turbine/7/temperature</c>).
    /// To define an asset property's alias, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_UpdateAssetProperty.html">UpdateAssetProperty</a>.
    /// </para></li></ul><important><para>
    /// With respect to Unix epoch time, IoT SiteWise accepts only TQVs that have a timestamp
    /// of no more than 7 days in the past and no more than 10 minutes in the future. IoT
    /// SiteWise rejects timestamps outside of the inclusive range of [-7 days, +10 minutes]
    /// and returns a <c>TimestampOutOfRangeException</c> error.
    /// </para><para>
    /// For each asset property, IoT SiteWise overwrites TQVs with duplicate timestamps unless
    /// the newer TQV has a different quality. For example, if you store a TQV <c>{T1, GOOD,
    /// V1}</c>, then storing <c>{T1, GOOD, V2}</c> replaces the existing TQV.
    /// </para></important><para>
    /// IoT SiteWise authorizes access to each <c>BatchPutAssetPropertyValue</c> entry individually.
    /// For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/security_iam_service-with-iam.html#security_iam_service-with-iam-id-based-policies-batchputassetpropertyvalue-action">BatchPutAssetPropertyValue
    /// authorization</a> in the <i>IoT SiteWise User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "IOTSWPutAssetPropertyValue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.BatchPutAssetPropertyErrorEntry")]
    [AWSCmdlet("Calls the AWS IoT SiteWise BatchPutAssetPropertyValue API operation.", Operation = new[] {"BatchPutAssetPropertyValue"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.BatchPutAssetPropertyErrorEntry or Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse",
        "This cmdlet returns a collection of Amazon.IoTSiteWise.Model.BatchPutAssetPropertyErrorEntry objects.",
        "The service call response (type Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportIOTSWPutAssetPropertyValueCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnablePartialEntryProcessing
        /// <summary>
        /// <para>
        /// <para>This setting enables partial ingestion at entry-level. If set to <c>true</c>, we ingest
        /// all TQVs not resulting in an error. If set to <c>false</c>, an invalid TQV fails ingestion
        /// of the entire entry that contains it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? EnablePartialEntryProcessing { get; set; }
        #endregion
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>The list of asset property value entries for the batch put request. You can specify
        /// up to 10 entries per request.</para>
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
        [Alias("Entries")]
        public Amazon.IoTSiteWise.Model.PutAssetPropertyValueEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ErrorEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ErrorEntries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EnablePartialEntryProcessing parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EnablePartialEntryProcessing' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EnablePartialEntryProcessing' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Entry), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-IOTSWPutAssetPropertyValue (BatchPutAssetPropertyValue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse, ImportIOTSWPutAssetPropertyValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EnablePartialEntryProcessing;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EnablePartialEntryProcessing = this.EnablePartialEntryProcessing;
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.IoTSiteWise.Model.PutAssetPropertyValueEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueRequest();
            
            if (cmdletContext.EnablePartialEntryProcessing != null)
            {
                request.EnablePartialEntryProcessing = cmdletContext.EnablePartialEntryProcessing.Value;
            }
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
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
        
        private Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "BatchPutAssetPropertyValue");
            try
            {
                #if DESKTOP
                return client.BatchPutAssetPropertyValue(request);
                #elif CORECLR
                return client.BatchPutAssetPropertyValueAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EnablePartialEntryProcessing { get; set; }
            public List<Amazon.IoTSiteWise.Model.PutAssetPropertyValueEntry> Entry { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.BatchPutAssetPropertyValueResponse, ImportIOTSWPutAssetPropertyValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ErrorEntries;
        }
        
    }
}
