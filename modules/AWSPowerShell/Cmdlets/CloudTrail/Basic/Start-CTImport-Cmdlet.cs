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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Starts an import of logged trail events from a source S3 bucket to a destination
    /// event data store. By default, CloudTrail only imports events contained in the S3 bucket's
    /// <c>CloudTrail</c> prefix and the prefixes inside the <c>CloudTrail</c> prefix, and
    /// does not check prefixes for other Amazon Web Services services. If you want to import
    /// CloudTrail events contained in another prefix, you must include the prefix in the
    /// <c>S3LocationUri</c>. For more considerations about importing trail events, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/cloudtrail-copy-trail-to-lake.html#cloudtrail-trail-copy-considerations">Considerations
    /// for copying trail events</a> in the <i>CloudTrail User Guide</i>. 
    /// 
    ///  
    /// <para>
    ///  When you start a new import, the <c>Destinations</c> and <c>ImportSource</c> parameters
    /// are required. Before starting a new import, disable any access control lists (ACLs)
    /// attached to the source S3 bucket. For more information about disabling ACLs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/about-object-ownership.html">Controlling
    /// ownership of objects and disabling ACLs for your bucket</a>. 
    /// </para><para>
    ///  When you retry an import, the <c>ImportID</c> parameter is required. 
    /// </para><note><para>
    ///  If the destination event data store is for an organization, you must use the management
    /// account to import trail events. You cannot use the delegated administrator account
    /// for the organization. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "CTImport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.StartImportResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail StartImport API operation.", Operation = new[] {"StartImport"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.StartImportResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.StartImportResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.StartImportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCTImportCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para> The ARN of the destination event data store. Use this parameter for a new import.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Destinations")]
        public System.String[] Destination { get; set; }
        #endregion
        
        #region Parameter EndEventTime
        /// <summary>
        /// <para>
        /// <para> Use with <c>StartEventTime</c> to bound a <c>StartImport</c> request, and limit imported
        /// trail events to only those events logged within a specified time period. When you
        /// specify a time range, CloudTrail checks the prefix and log file names to verify the
        /// names contain a date between the specified <c>StartEventTime</c> and <c>EndEventTime</c>
        /// before attempting to import events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndEventTime { get; set; }
        #endregion
        
        #region Parameter ImportId
        /// <summary>
        /// <para>
        /// <para> The ID of the import. Use this parameter when you are retrying an import. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImportId { get; set; }
        #endregion
        
        #region Parameter S3_S3BucketAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The IAM ARN role used to access the source S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportSource_S3_S3BucketAccessRoleArn")]
        public System.String S3_S3BucketAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter S3_S3BucketRegion
        /// <summary>
        /// <para>
        /// <para> The Region associated with the source S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportSource_S3_S3BucketRegion")]
        public System.String S3_S3BucketRegion { get; set; }
        #endregion
        
        #region Parameter S3_S3LocationUri
        /// <summary>
        /// <para>
        /// <para> The URI for the source S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportSource_S3_S3LocationUri")]
        public System.String S3_S3LocationUri { get; set; }
        #endregion
        
        #region Parameter StartEventTime
        /// <summary>
        /// <para>
        /// <para> Use with <c>EndEventTime</c> to bound a <c>StartImport</c> request, and limit imported
        /// trail events to only those events logged within a specified time period. When you
        /// specify a time range, CloudTrail checks the prefix and log file names to verify the
        /// names contain a date between the specified <c>StartEventTime</c> and <c>EndEventTime</c>
        /// before attempting to import events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartEventTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.StartImportResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.StartImportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Destination parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Destination' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Destination' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImportId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CTImport (StartImport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.StartImportResponse, StartCTImportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Destination;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Destination != null)
            {
                context.Destination = new List<System.String>(this.Destination);
            }
            context.EndEventTime = this.EndEventTime;
            context.ImportId = this.ImportId;
            context.S3_S3BucketAccessRoleArn = this.S3_S3BucketAccessRoleArn;
            context.S3_S3BucketRegion = this.S3_S3BucketRegion;
            context.S3_S3LocationUri = this.S3_S3LocationUri;
            context.StartEventTime = this.StartEventTime;
            
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
            var request = new Amazon.CloudTrail.Model.StartImportRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.EndEventTime != null)
            {
                request.EndEventTime = cmdletContext.EndEventTime.Value;
            }
            if (cmdletContext.ImportId != null)
            {
                request.ImportId = cmdletContext.ImportId;
            }
            
             // populate ImportSource
            var requestImportSourceIsNull = true;
            request.ImportSource = new Amazon.CloudTrail.Model.ImportSource();
            Amazon.CloudTrail.Model.S3ImportSource requestImportSource_importSource_S3 = null;
            
             // populate S3
            var requestImportSource_importSource_S3IsNull = true;
            requestImportSource_importSource_S3 = new Amazon.CloudTrail.Model.S3ImportSource();
            System.String requestImportSource_importSource_S3_s3_S3BucketAccessRoleArn = null;
            if (cmdletContext.S3_S3BucketAccessRoleArn != null)
            {
                requestImportSource_importSource_S3_s3_S3BucketAccessRoleArn = cmdletContext.S3_S3BucketAccessRoleArn;
            }
            if (requestImportSource_importSource_S3_s3_S3BucketAccessRoleArn != null)
            {
                requestImportSource_importSource_S3.S3BucketAccessRoleArn = requestImportSource_importSource_S3_s3_S3BucketAccessRoleArn;
                requestImportSource_importSource_S3IsNull = false;
            }
            System.String requestImportSource_importSource_S3_s3_S3BucketRegion = null;
            if (cmdletContext.S3_S3BucketRegion != null)
            {
                requestImportSource_importSource_S3_s3_S3BucketRegion = cmdletContext.S3_S3BucketRegion;
            }
            if (requestImportSource_importSource_S3_s3_S3BucketRegion != null)
            {
                requestImportSource_importSource_S3.S3BucketRegion = requestImportSource_importSource_S3_s3_S3BucketRegion;
                requestImportSource_importSource_S3IsNull = false;
            }
            System.String requestImportSource_importSource_S3_s3_S3LocationUri = null;
            if (cmdletContext.S3_S3LocationUri != null)
            {
                requestImportSource_importSource_S3_s3_S3LocationUri = cmdletContext.S3_S3LocationUri;
            }
            if (requestImportSource_importSource_S3_s3_S3LocationUri != null)
            {
                requestImportSource_importSource_S3.S3LocationUri = requestImportSource_importSource_S3_s3_S3LocationUri;
                requestImportSource_importSource_S3IsNull = false;
            }
             // determine if requestImportSource_importSource_S3 should be set to null
            if (requestImportSource_importSource_S3IsNull)
            {
                requestImportSource_importSource_S3 = null;
            }
            if (requestImportSource_importSource_S3 != null)
            {
                request.ImportSource.S3 = requestImportSource_importSource_S3;
                requestImportSourceIsNull = false;
            }
             // determine if request.ImportSource should be set to null
            if (requestImportSourceIsNull)
            {
                request.ImportSource = null;
            }
            if (cmdletContext.StartEventTime != null)
            {
                request.StartEventTime = cmdletContext.StartEventTime.Value;
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
        
        private Amazon.CloudTrail.Model.StartImportResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.StartImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "StartImport");
            try
            {
                #if DESKTOP
                return client.StartImport(request);
                #elif CORECLR
                return client.StartImportAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Destination { get; set; }
            public System.DateTime? EndEventTime { get; set; }
            public System.String ImportId { get; set; }
            public System.String S3_S3BucketAccessRoleArn { get; set; }
            public System.String S3_S3BucketRegion { get; set; }
            public System.String S3_S3LocationUri { get; set; }
            public System.DateTime? StartEventTime { get; set; }
            public System.Func<Amazon.CloudTrail.Model.StartImportResponse, StartCTImportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
