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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Creates an Ephemeris with the specified <c>EphemerisData</c>.
    /// </summary>
    [Cmdlet("New", "GSEphemeris", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station CreateEphemeris API operation.", Operation = new[] {"CreateEphemeris"}, SelectReturnType = typeof(Amazon.GroundStation.Model.CreateEphemerisResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.CreateEphemerisResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.CreateEphemerisResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGSEphemerisCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Ephemeris_Oem_S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 Bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Oem_S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Tle_S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 Bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Tle_S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Whether to set the ephemeris status to <c>ENABLED</c> after validation.</para><para>Setting this to false will set the ephemeris status to <c>DISABLED</c> after validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter ExpirationTime
        /// <summary>
        /// <para>
        /// <para>An overall expiration time for the ephemeris in UTC, after which it will become <c>EXPIRED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpirationTime { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Oem_S3Object_Key
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 key for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Oem_S3Object_Key { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Tle_S3Object_Key
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 key for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Tle_S3Object_Key { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a KMS key used to encrypt the ephemeris in Ground Station.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name string associated with the ephemeris. Used as a human-readable identifier for
        /// the ephemeris.</para>
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
        
        #region Parameter Oem_OemData
        /// <summary>
        /// <para>
        /// <para>The data for an OEM ephemeris, supplied directly in the request rather than through
        /// an S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_Oem_OemData")]
        public System.String Oem_OemData { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>Customer-provided priority score to establish the order in which overlapping ephemerides
        /// should be used.</para><para>The default for customer-provided ephemeris priority is 1, and higher numbers take
        /// precedence.</para><para>Priority must be 1 or greater</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter SatelliteId
        /// <summary>
        /// <para>
        /// <para>AWS Ground Station satellite ID for this ephemeris.</para>
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
        public System.String SatelliteId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to an ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Tle_TleData
        /// <summary>
        /// <para>
        /// <para>The data for a TLE ephemeris, supplied directly in the request rather than through
        /// an S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_Tle_TleData")]
        public Amazon.GroundStation.Model.TLEData[] Tle_TleData { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Oem_S3Object_Version
        /// <summary>
        /// <para>
        /// <para>For versioned S3 objects, the version to use for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Oem_S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Tle_S3Object_Version
        /// <summary>
        /// <para>
        /// <para>For versioned S3 objects, the version to use for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Tle_S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EphemerisId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.CreateEphemerisResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.CreateEphemerisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EphemerisId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GSEphemeris (CreateEphemeris)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.CreateEphemerisResponse, NewGSEphemerisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            context.Oem_OemData = this.Oem_OemData;
            context.Ephemeris_Oem_S3Object_Bucket = this.Ephemeris_Oem_S3Object_Bucket;
            context.Ephemeris_Oem_S3Object_Key = this.Ephemeris_Oem_S3Object_Key;
            context.Ephemeris_Oem_S3Object_Version = this.Ephemeris_Oem_S3Object_Version;
            context.Ephemeris_Tle_S3Object_Bucket = this.Ephemeris_Tle_S3Object_Bucket;
            context.Ephemeris_Tle_S3Object_Key = this.Ephemeris_Tle_S3Object_Key;
            context.Ephemeris_Tle_S3Object_Version = this.Ephemeris_Tle_S3Object_Version;
            if (this.Tle_TleData != null)
            {
                context.Tle_TleData = new List<Amazon.GroundStation.Model.TLEData>(this.Tle_TleData);
            }
            context.ExpirationTime = this.ExpirationTime;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            context.SatelliteId = this.SatelliteId;
            #if MODULAR
            if (this.SatelliteId == null && ParameterWasBound(nameof(this.SatelliteId)))
            {
                WriteWarning("You are passing $null as a value for parameter SatelliteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.GroundStation.Model.CreateEphemerisRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            
             // populate Ephemeris
            var requestEphemerisIsNull = true;
            request.Ephemeris = new Amazon.GroundStation.Model.EphemerisData();
            Amazon.GroundStation.Model.OEMEphemeris requestEphemeris_ephemeris_Oem = null;
            
             // populate Oem
            var requestEphemeris_ephemeris_OemIsNull = true;
            requestEphemeris_ephemeris_Oem = new Amazon.GroundStation.Model.OEMEphemeris();
            System.String requestEphemeris_ephemeris_Oem_oem_OemData = null;
            if (cmdletContext.Oem_OemData != null)
            {
                requestEphemeris_ephemeris_Oem_oem_OemData = cmdletContext.Oem_OemData;
            }
            if (requestEphemeris_ephemeris_Oem_oem_OemData != null)
            {
                requestEphemeris_ephemeris_Oem.OemData = requestEphemeris_ephemeris_Oem_oem_OemData;
                requestEphemeris_ephemeris_OemIsNull = false;
            }
            Amazon.GroundStation.Model.S3Object requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object = null;
            
             // populate S3Object
            var requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = true;
            requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object = new Amazon.GroundStation.Model.S3Object();
            System.String requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket = null;
            if (cmdletContext.Ephemeris_Oem_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket = cmdletContext.Ephemeris_Oem_S3Object_Bucket;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object.Bucket = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket;
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key = null;
            if (cmdletContext.Ephemeris_Oem_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key = cmdletContext.Ephemeris_Oem_S3Object_Key;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object.Key = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key;
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version = null;
            if (cmdletContext.Ephemeris_Oem_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version = cmdletContext.Ephemeris_Oem_S3Object_Version;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object.Version = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version;
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object should be set to null
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object = null;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object != null)
            {
                requestEphemeris_ephemeris_Oem.S3Object = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object;
                requestEphemeris_ephemeris_OemIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Oem should be set to null
            if (requestEphemeris_ephemeris_OemIsNull)
            {
                requestEphemeris_ephemeris_Oem = null;
            }
            if (requestEphemeris_ephemeris_Oem != null)
            {
                request.Ephemeris.Oem = requestEphemeris_ephemeris_Oem;
                requestEphemerisIsNull = false;
            }
            Amazon.GroundStation.Model.TLEEphemeris requestEphemeris_ephemeris_Tle = null;
            
             // populate Tle
            var requestEphemeris_ephemeris_TleIsNull = true;
            requestEphemeris_ephemeris_Tle = new Amazon.GroundStation.Model.TLEEphemeris();
            List<Amazon.GroundStation.Model.TLEData> requestEphemeris_ephemeris_Tle_tle_TleData = null;
            if (cmdletContext.Tle_TleData != null)
            {
                requestEphemeris_ephemeris_Tle_tle_TleData = cmdletContext.Tle_TleData;
            }
            if (requestEphemeris_ephemeris_Tle_tle_TleData != null)
            {
                requestEphemeris_ephemeris_Tle.TleData = requestEphemeris_ephemeris_Tle_tle_TleData;
                requestEphemeris_ephemeris_TleIsNull = false;
            }
            Amazon.GroundStation.Model.S3Object requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object = null;
            
             // populate S3Object
            var requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = true;
            requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object = new Amazon.GroundStation.Model.S3Object();
            System.String requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket = null;
            if (cmdletContext.Ephemeris_Tle_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket = cmdletContext.Ephemeris_Tle_S3Object_Bucket;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object.Bucket = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket;
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key = null;
            if (cmdletContext.Ephemeris_Tle_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key = cmdletContext.Ephemeris_Tle_S3Object_Key;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object.Key = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key;
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version = null;
            if (cmdletContext.Ephemeris_Tle_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version = cmdletContext.Ephemeris_Tle_S3Object_Version;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object.Version = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version;
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object should be set to null
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object = null;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object != null)
            {
                requestEphemeris_ephemeris_Tle.S3Object = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object;
                requestEphemeris_ephemeris_TleIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Tle should be set to null
            if (requestEphemeris_ephemeris_TleIsNull)
            {
                requestEphemeris_ephemeris_Tle = null;
            }
            if (requestEphemeris_ephemeris_Tle != null)
            {
                request.Ephemeris.Tle = requestEphemeris_ephemeris_Tle;
                requestEphemerisIsNull = false;
            }
             // determine if request.Ephemeris should be set to null
            if (requestEphemerisIsNull)
            {
                request.Ephemeris = null;
            }
            if (cmdletContext.ExpirationTime != null)
            {
                request.ExpirationTime = cmdletContext.ExpirationTime.Value;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.SatelliteId != null)
            {
                request.SatelliteId = cmdletContext.SatelliteId;
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
        
        private Amazon.GroundStation.Model.CreateEphemerisResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.CreateEphemerisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "CreateEphemeris");
            try
            {
                #if DESKTOP
                return client.CreateEphemeris(request);
                #elif CORECLR
                return client.CreateEphemerisAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public System.String Oem_OemData { get; set; }
            public System.String Ephemeris_Oem_S3Object_Bucket { get; set; }
            public System.String Ephemeris_Oem_S3Object_Key { get; set; }
            public System.String Ephemeris_Oem_S3Object_Version { get; set; }
            public System.String Ephemeris_Tle_S3Object_Bucket { get; set; }
            public System.String Ephemeris_Tle_S3Object_Key { get; set; }
            public System.String Ephemeris_Tle_S3Object_Version { get; set; }
            public List<Amazon.GroundStation.Model.TLEData> Tle_TleData { get; set; }
            public System.DateTime? ExpirationTime { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String SatelliteId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GroundStation.Model.CreateEphemerisResponse, NewGSEphemerisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EphemerisId;
        }
        
    }
}
