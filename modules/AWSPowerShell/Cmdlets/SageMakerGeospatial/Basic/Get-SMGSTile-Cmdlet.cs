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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Gets a web mercator tile for the given Earth Observation job.
    /// </summary>
    [Cmdlet("Get", "SMGSTile")]
    [OutputType("System.IO.Stream")]
    [AWSCmdlet("Calls the SageMaker Geospatial GetTile API operation.", Operation = new[] {"GetTile"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.GetTileResponse))]
    [AWSCmdletOutput("System.IO.Stream or Amazon.SageMakerGeospatial.Model.GetTileResponse",
        "This cmdlet returns a System.IO.Stream object.",
        "The service call response (type Amazon.SageMakerGeospatial.Model.GetTileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMGSTileCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the tile operation.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ImageAsset
        /// <summary>
        /// <para>
        /// <para>The particular assets or bands to tile.</para>
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
        [Alias("ImageAssets")]
        public System.String[] ImageAsset { get; set; }
        #endregion
        
        #region Parameter ImageMask
        /// <summary>
        /// <para>
        /// <para>Determines whether or not to return a valid data mask.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageMask { get; set; }
        #endregion
        
        #region Parameter OutputDataType
        /// <summary>
        /// <para>
        /// <para>The output data type of the tile operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.OutputType")]
        public Amazon.SageMakerGeospatial.OutputType OutputDataType { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The data format of the output tile. The formats include .npy, .png and .jpg.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputFormat { get; set; }
        #endregion
        
        #region Parameter PropertyFilter
        /// <summary>
        /// <para>
        /// <para>Property filters for the imagery to tile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropertyFilters")]
        public System.String PropertyFilter { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>Determines what part of the Earth Observation job to tile. 'INPUT' or 'OUTPUT' are
        /// the valid options.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.TargetOptions")]
        public Amazon.SageMakerGeospatial.TargetOptions Target { get; set; }
        #endregion
        
        #region Parameter TimeRangeFilter
        /// <summary>
        /// <para>
        /// <para>Time range filter applied to imagery to find the images to tile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeRangeFilter { get; set; }
        #endregion
        
        #region Parameter X
        /// <summary>
        /// <para>
        /// <para>The x coordinate of the tile input.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? X { get; set; }
        #endregion
        
        #region Parameter Y
        /// <summary>
        /// <para>
        /// <para>The y coordinate of the tile input.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Y { get; set; }
        #endregion
        
        #region Parameter Z
        /// <summary>
        /// <para>
        /// <para>The z coordinate of the tile input.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Z { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BinaryFile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.GetTileResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.GetTileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BinaryFile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.GetTileResponse, GetSMGSTileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            if (this.ImageAsset != null)
            {
                context.ImageAsset = new List<System.String>(this.ImageAsset);
            }
            #if MODULAR
            if (this.ImageAsset == null && ParameterWasBound(nameof(this.ImageAsset)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageAsset which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageMask = this.ImageMask;
            context.OutputDataType = this.OutputDataType;
            context.OutputFormat = this.OutputFormat;
            context.PropertyFilter = this.PropertyFilter;
            context.Target = this.Target;
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeRangeFilter = this.TimeRangeFilter;
            context.X = this.X;
            #if MODULAR
            if (this.X == null && ParameterWasBound(nameof(this.X)))
            {
                WriteWarning("You are passing $null as a value for parameter X which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Y = this.Y;
            #if MODULAR
            if (this.Y == null && ParameterWasBound(nameof(this.Y)))
            {
                WriteWarning("You are passing $null as a value for parameter Y which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Z = this.Z;
            #if MODULAR
            if (this.Z == null && ParameterWasBound(nameof(this.Z)))
            {
                WriteWarning("You are passing $null as a value for parameter Z which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerGeospatial.Model.GetTileRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.ImageAsset != null)
            {
                request.ImageAssets = cmdletContext.ImageAsset;
            }
            if (cmdletContext.ImageMask != null)
            {
                request.ImageMask = cmdletContext.ImageMask.Value;
            }
            if (cmdletContext.OutputDataType != null)
            {
                request.OutputDataType = cmdletContext.OutputDataType;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            if (cmdletContext.PropertyFilter != null)
            {
                request.PropertyFilters = cmdletContext.PropertyFilter;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
            }
            if (cmdletContext.TimeRangeFilter != null)
            {
                request.TimeRangeFilter = cmdletContext.TimeRangeFilter;
            }
            if (cmdletContext.X != null)
            {
                request.X = cmdletContext.X.Value;
            }
            if (cmdletContext.Y != null)
            {
                request.Y = cmdletContext.Y.Value;
            }
            if (cmdletContext.Z != null)
            {
                request.Z = cmdletContext.Z.Value;
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
        
        private Amazon.SageMakerGeospatial.Model.GetTileResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.GetTileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "GetTile");
            try
            {
                #if DESKTOP
                return client.GetTile(request);
                #elif CORECLR
                return client.GetTileAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public List<System.String> ImageAsset { get; set; }
            public System.Boolean? ImageMask { get; set; }
            public Amazon.SageMakerGeospatial.OutputType OutputDataType { get; set; }
            public System.String OutputFormat { get; set; }
            public System.String PropertyFilter { get; set; }
            public Amazon.SageMakerGeospatial.TargetOptions Target { get; set; }
            public System.String TimeRangeFilter { get; set; }
            public System.Int32? X { get; set; }
            public System.Int32? Y { get; set; }
            public System.Int32? Z { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.GetTileResponse, GetSMGSTileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BinaryFile;
        }
        
    }
}
